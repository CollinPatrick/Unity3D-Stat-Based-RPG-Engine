public class ResourceStat : BaseStat
{
    int value;
    int maxValue;

    public ResourceStat(int v, int m, StatTypes s) : base(s)
    {
        value = v;
        maxValue = m;
    }

    public override int GetValue()
    {
        return value;
    }

    public override int GetMaxValue()
    {
        return maxValue;
    }

    public override void SetValue(int v)
    {
        value = v;
    }

    public override void SetMaxValue(int m)
    {
        maxValue = m;
    }
}
