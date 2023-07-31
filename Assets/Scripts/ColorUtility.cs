using UnityEngine;

public static class ColorUtility
{
    public static float CalculateColorDifference(Color color1, Color color2)
    {
        // Convert the colors to CIELAB color space
        ColorLab labColor1 = RGBToLab(color1);
        ColorLab labColor2 = RGBToLab(color2);

        // Calculate the differences in L*, a*, and b* components
        float deltaL = labColor1.L - labColor2.L;
        float deltaA = labColor1.A - labColor2.A;
        float deltaB = labColor1.B - labColor2.B;

        // Calculate the total color difference (Delta E)
        float deltaE = Mathf.Sqrt(deltaL * deltaL + deltaA * deltaA + deltaB * deltaB);

        // Normalize the Delta E value to a similarity value (inverted)
        const float maxDeltaE = 100f;
        float similarityPercentage = 1f - (deltaE / maxDeltaE);

        return similarityPercentage;
    }

    // Helper function to convert RGB color to CIELAB color space
    private static ColorLab RGBToLab(Color color)
    {
        float r = color.r;
        float g = color.g;
        float b = color.b;

        float x = r * 0.4124564f + g * 0.3575761f + b * 0.1804375f;
        float y = r * 0.2126729f + g * 0.7151522f + b * 0.0721750f;
        float z = r * 0.0193339f + g * 0.1191920f + b * 0.9503041f;

        x /= 0.95047f; // Observer = 2°, Illuminant = D65
        y /= 1.0f;
        z /= 1.08883f;

        x = XYZToLab(x);
        y = XYZToLab(y);
        z = XYZToLab(z);

        float l = Mathf.Max(0f, (116f * y) - 16f);
        float a = 500f * (x - y);
        float bValue = 200f * (y - z);

        return new ColorLab(l, a, bValue);
    }

    // Helper function to convert XYZ color to CIELAB color space
    private static float XYZToLab(float value)
    {
        const float threshold = 0.008856f;
        const float factor = 7.787f;

        if (value > threshold)
        {
            return Mathf.Pow(value, 1f / 3f);
        }

        return (factor * value) + (16f / 116f);
    }

    // Helper struct to hold CIELAB components
    private struct ColorLab
    {
        public float L;
        public float A;
        public float B;

        public ColorLab(float l, float a, float b)
        {
            L = l;
            A = a;
            B = b;
        }
    }
}