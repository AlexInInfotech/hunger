using UnityEngine;
using UnityEngine.Tilemaps;



public static class TileControl
{
    static RuleGraph RuleGraph = new RuleGraph();
    static RuleGraph transitRuleGragh = new RuleGraph();
    static byte[] order = { 5, 1, 3, 7, 8, 2, 0, 6 };

    class Rule
    {
        public bool[] path;
        public TileForm tileform;

        public Rule(bool[] _path, TileForm _tileform)
        {
            path = _path;
            tileform = _tileform;
        }
    }

    private static void AddRule(Rule rule, RuleGraph rulegragh)
    {
        RuleGraph CurrentGraph = rulegragh;
        for (byte i = 0; i < rule.path.Length; i++)
        {
            if (rule.path[i])
            {
                if (CurrentGraph.one == null)
                    CurrentGraph.one = new RuleGraph();
                CurrentGraph = CurrentGraph.one;
            }
            else
            {
                if (CurrentGraph.zero == null)
                    CurrentGraph.zero = new RuleGraph();
                CurrentGraph = CurrentGraph.zero;
            }
        }
        CurrentGraph.rule = rule.tileform;
    }
    public static void SetRules() //  ���������� ��� ������ ���� ���
    {
        Rule[] rules = new Rule[9];
        bool[] Fill_Path = { true, true, true, true};
        bool[] CornerLeftBottom_Path = { false, false };
        bool[] CornerLeftTop_Path = { false, true, true, false };
        bool[] CornerRightBottom_Path = { true, false, false };
        bool[] CornerRightTop_Path = { true, true, false, false };
        bool[] WallLeft_Path = { false, true, true, true };
        bool[] WallRight_Path = { true, true, false, true };
        bool[] WallTop_Path = { true, true, true, false };
        bool[] WallBottom_Path = { true, false, true };
        rules[0] = new Rule(Fill_Path, TileForm.Fill);
        rules[1] = new Rule(CornerLeftBottom_Path, TileForm.Corner_LeftBottom);
        rules[2] = new Rule(CornerLeftTop_Path, TileForm.Corner_LeftTop);
        rules[3] = new Rule(CornerRightBottom_Path, TileForm.Corner_RightBottom);
        rules[4] = new Rule(CornerRightTop_Path, TileForm.Corner_RightTop);
        rules[5] = new Rule(WallLeft_Path, TileForm.Wall_Left);
        rules[6] = new Rule(WallRight_Path, TileForm.Wall_Right);
        rules[7] = new Rule(WallTop_Path, TileForm.Wall_Top);
        rules[8] = new Rule(WallBottom_Path, TileForm.Wall_Bottom);

        Rule[] Transitrules = new Rule[12];
        bool[] TransitCornerLeftBottom_Path = { true, true, true, true, true, true, true, false };
        bool[] TransitCornerLeftTop_Path = { true, true, true, true, true, true, false };
        bool[] TransitCornerRightBottom_Path = { true, true, true, true, false };
        bool[] TransitCornerRightTop_Path = { true, true, true, true, true, false };
        bool[] TransitWallLeft_Path = { true, true, false, true };
        bool[] TransitWallRight_Path = { false, true,  true, true,};
        bool[] TransitWallTop_Path = { true, false, true };
        bool[] TransitWallBottom_Path = {true, true, true, false };
        bool[] TransitHallLeftBottom_Path = { false, false };
        bool[] TransitHallLeftTop_Path = { false, true, true, false };
        bool[] TransitHallRightBottom_Path = { true, false, false };
        bool[] TransitHallRightTop_Path = { true, true, false, false };
        Transitrules[0] = new Rule(TransitHallLeftBottom_Path, TileForm.Hall_LeftBottom);
        Transitrules[1] = new Rule(TransitHallLeftTop_Path, TileForm.Hall_LeftTop);
        Transitrules[2]= new Rule(TransitHallRightBottom_Path, TileForm.Hall_RightBottom);
        Transitrules[3] = new Rule(TransitHallRightTop_Path, TileForm.Hall_RightTop);
        Transitrules[4] = new Rule(TransitCornerLeftBottom_Path, TileForm.Corner_LeftBottom);
        Transitrules[5] = new Rule(TransitCornerLeftTop_Path, TileForm.Corner_LeftTop);
        Transitrules[6] = new Rule(TransitCornerRightBottom_Path, TileForm.Corner_RightBottom);
        Transitrules[7] = new Rule(TransitCornerRightTop_Path, TileForm.Corner_RightTop);
        Transitrules[8] = new Rule(TransitWallLeft_Path, TileForm.Wall_Left);
        Transitrules[9] = new Rule(TransitWallRight_Path, TileForm.Wall_Right);
        Transitrules[10] = new Rule(TransitWallTop_Path, TileForm.Wall_Top);
        Transitrules[11] = new Rule(TransitWallBottom_Path, TileForm.Wall_Bottom);
        for (byte i = 0; i < Transitrules.Length; i++)
            AddRule(Transitrules[i], transitRuleGragh);
        for (byte i = 0; i < rules.Length; i++)
            AddRule(rules[i], RuleGraph);
    }
    public static GroundData GetCorrectTiles(TileType[] neighbors, BiomType[] bioms)
    {
        GroundData OutData = new GroundData();
        BiomType transitBiom = new BiomType();
        GroundBase ground = GetGroundBase(neighbors[4]);
        TileForm TileForm = new TileForm();
        TileForm TransitionForm = new TileForm();
        if (neighbors[4] == TileType.water)
            TileForm = TileForm.Fill;
        else
            TileForm = GetRule(neighbors, RuleGraph);
        TransitionForm = GetRule(bioms, transitRuleGragh, ref transitBiom);

        OutData.Tile = ground.GetTile(TileForm, bioms[4]);
        OutData.States3.r = ground.GetRedState(bioms[4]);
        OutData.States3.g = ground.GetGreenState(TransitionForm, transitBiom);
        OutData.States3.a = 1;
        OutData.Tilemap = ground.tilemap;
        OutData.TileType = neighbors[4];
        return OutData;
    }
 
    private static GroundBase GetGroundBase(TileType ground)
    {
        switch (ground)
        {
            case TileType.water:
                return TilePallet.Water;
            case TileType.sand:
                return TilePallet.Sand;
            case TileType.earth:
                return TilePallet.Earth;
            default:
                return null;
        }
    }
    private static TileForm GetRule(TileType[] neighbors, RuleGraph rules)
    {
        byte i = 0;
        RuleGraph Currentgraph = rules;
        TileForm TileForm = new TileForm();
        while (Currentgraph != null && i < order.Length)
        {
            if (neighbors[order[i]] >= neighbors[4])
                Currentgraph = Currentgraph.one;
            else
                Currentgraph = Currentgraph.zero;
            if (Currentgraph != null)
                TileForm = Currentgraph.rule;
            i++;
        }
        return TileForm;
    }
    //public static void CheckBiomRules()
    //{
    //    BiomType[] neighbors =
    //    {
    //        BiomType.usual, BiomType.usual, BiomType.usual,
    //        BiomType.atlantic, BiomType.atlantic, BiomType.usual,
    //        BiomType.atlantic, BiomType.atlantic, BiomType.usual
    //    };
    //    BiomType transit = new BiomType();
    //    Debug.Log(GetRule(neighbors, transitRuleGragh, ref transit) + " " + transit);

    //}
    private static TileForm GetRule(BiomType[] neighbors, RuleGraph rules, ref BiomType transitBiom)
    {
        byte i = 0;
        RuleGraph Currentgraph = rules;
        TileForm TileForm = new TileForm();
        while (Currentgraph != null && i < order.Length)
        {
            if (neighbors[order[i]] <= neighbors[4])
                Currentgraph = Currentgraph.one;
            else
            {
                transitBiom = neighbors[order[i]];
                Currentgraph = Currentgraph.zero;
            }
            if (Currentgraph != null)
                TileForm = Currentgraph.rule;
            i++;
        }
        return TileForm;
    }
}