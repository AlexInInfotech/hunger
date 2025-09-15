using System;
using UnityEngine;

public static class MapGenerator 
{
    public static float[] Generate(int width, MapCharcteristics mapCharac, Vector2 offset)//, float power)
    {
        int random;
        float[] Map = new float[width * width];
        System.Random rand = new System.Random(mapCharac.seed);

        Vector2[] octavesOffset = new Vector2[mapCharac.octaves];
        for (int i = 0; i < mapCharac.octaves; i++)
        {
            random = rand.Next(-100000, 100000);
            float xOffset = random + offset.x;
            float yOffset = random + offset.y;

            //float xOffset = offset.x;
            //float yOffset = offset.y;
            //  octavesOffset[i] = new Vector2(xOffset / width, yOffset / width);
            octavesOffset[i] = new Vector2(xOffset, yOffset);
        }
        if (mapCharac.scale < 0) mapCharac.scale = 0.0001f;

        float halfWidth = width / 2f;
        float halfHeight = width / 2f;

        for (int y = 0; y < width; y++)
        {
            for (int x = 0; x < width; x++)
            {
                // Задаём значения для первой октавы
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;
                float superpositionCompensation = 0;

                // Обработка наложения октав
                for (int i = 0; i < mapCharac.octaves; i++)
                {
                    // Рассчитываем координаты для получения значения из Шума Перлина
                    float xResult = (x - halfWidth) / mapCharac.scale * frequency + octavesOffset[i].x * frequency;
                    float yResult = (y - halfHeight) / mapCharac.scale * frequency + octavesOffset[i].y * frequency;

                    // Получение высоты из ГСПЧ
                    float generatedValue = Mathf.PerlinNoise(xResult, yResult);
                    // Наложение октав
                    noiseHeight += generatedValue * amplitude;
                    // Компенсируем наложение октав, чтобы остаться в границах диапазона [0,1]
                    noiseHeight -= superpositionCompensation;

                    // Расчёт амплитуды, частоты и компенсации для следующей октавы
                    amplitude *= mapCharac.persistence;
                    frequency *= mapCharac.lacunarity;
                    superpositionCompensation = amplitude / 2;
                }

                // Сохраняем точку для карты высот
                // Из-за наложения октав есть вероятность выхода за границы диапазона [0,1]
                Map[y * width + x] = Mathf.Clamp01(noiseHeight);
            }
        }
       // ApplyGaussian(Map, power, width);
        return Map;
    }
    public static void UniteMainWidthRiver(float[] MainMap, float[] RiverMap)
    {
        for (int i = 0; i < MainMap.Length; i++)
            if (TileManager.IsItRiver(RiverMap[i]))
                MainMap[i] = 0;
    }
    public static float[] UniteBioms(int width, float[][] BiomsMap)
    {
        float[] Bioms = BiomsMap[0];
        BiomType biomType = BiomType.atlantic;
        foreach (float[] value in BiomsMap)
        {
            for (int i = 0; i < value.Length; i++)
                if (TileManager.IsItBiom(value[i]))
                    Bioms[i] = (int)biomType + value[i];
            biomType++;
        }
        return Bioms;
    }

    private static void ApplyGaussian(float[] map, float power, int width)
    {
        int i = 0;
        Vector2Int size = new Vector2Int(map.Length / width, width);
        for (int x = 0; x < size.x; x++)
            for (int y = 0; y < size.y; y++){
                double distance = Math.Pow(x - size.x / 2f, 4) + Math.Pow(y - size.y / 2f, 4);
                // double gaussValue = Math.Exp(-distance / (Math.Pow(size.x / 2f, 3) * 3));
                double gaussValue = Math.Exp(-distance / (Math.Pow(size.x, 3) * 2));
                map[i] *= (float)gaussValue * power;
                i++;
            }
    }
}
