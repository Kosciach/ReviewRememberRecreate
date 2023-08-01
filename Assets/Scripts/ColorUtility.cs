using UnityEngine;

public static class ColorUtility
{
    // Calculate the CIEDE2000 color difference between two RGB colors
    public static float CalculateCIEDE2000(Color color1, Color color2)
    {
        // Convert RGB colors to LAB color space
        ColorLAB lab1 = RGBtoLAB(color1);
        ColorLAB lab2 = RGBtoLAB(color2);

        // Calculate CIEDE2000 difference
        return CIEDE2000(lab1, lab2);
    }

    private static ColorLAB RGBtoLAB(Color color)
    {
        // Convert RGB to XYZ
        float r = RGBtoXYZ(color.r);
        float g = RGBtoXYZ(color.g);
        float b = RGBtoXYZ(color.b);

        // Convert XYZ to LAB
        float x = XYZtoLAB(r);
        float y = XYZtoLAB(g);
        float z = XYZtoLAB(b);

        return new ColorLAB(x, y, z);
    }

    private static float RGBtoXYZ(float value)
    {
        return value > 0.04045f ? Mathf.Pow((value + 0.055f) / 1.055f, 2.4f) : value / 12.92f;
    }

    private static float XYZtoLAB(float value)
    {
        return value > 0.008856f ? Mathf.Pow(value, 1.0f / 3.0f) : (903.3f * value + 16) / 116;
    }

    private static float CIEDE2000(ColorLAB lab1, ColorLAB lab2)
    {
        float l1 = lab1.L;
        float a1 = lab1.A;
        float b1 = lab1.B;
        float l2 = lab2.L;
        float a2 = lab2.A;
        float b2 = lab2.B;

        float kL = 1.0f;
        float kC = 1.0f;
        float kH = 1.0f;

        float C1 = Mathf.Sqrt(a1 * a1 + b1 * b1);
        float C2 = Mathf.Sqrt(a2 * a2 + b2 * b2);
        float a_C1_C2 = (C1 + C2) / 2.0f;

        float G = 0.5f * (1.0f - Mathf.Sqrt(Mathf.Pow(a_C1_C2, 7.0f) / (Mathf.Pow(a_C1_C2, 7.0f) + Mathf.Pow(25.0f, 7.0f))));

        float a1p = (1.0f + G) * a1;
        float a2p = (1.0f + G) * a2;
        float C1p = Mathf.Sqrt(a1p * a1p + b1 * b1);
        float C2p = Mathf.Sqrt(a2p * a2p + b2 * b2);

        float h1p = Mathf.Atan2(b1, a1p);
        if (h1p < 0)
            h1p += 2 * Mathf.PI;
        float h2p = Mathf.Atan2(b2, a2p);
        if (h2p < 0)
            h2p += 2 * Mathf.PI;

        float dLp = l2 - l1;
        float dCp = C2p - C1p;
        float dhp = h2p - h1p;
        if (dhp > Mathf.PI)
            dhp -= 2 * Mathf.PI;
        if (dhp < -Mathf.PI)
            dhp += 2 * Mathf.PI;
        if (C1p * C2p == 0)
            dhp = 0;

        float dHp = 2 * Mathf.Sqrt(C1p * C2p) * Mathf.Sin(dhp / 2.0f);

        float a_C1p_C2p = (C1p + C2p) / 2.0f;
        float h_C1p_C2p = (h1p + h2p) / 2.0f;

        float T = 1 - 0.17f * Mathf.Cos(h_C1p_C2p - Mathf.PI / 6) + 0.24f * Mathf.Cos(2 * h_C1p_C2p) + 0.32f * Mathf.Cos(3 * h_C1p_C2p + Mathf.PI / 30) - 0.20f * Mathf.Cos(4 * h_C1p_C2p - 21 * Mathf.PI / 60);
        float dTheta = Mathf.PI / 3 * Mathf.Exp(-Mathf.Pow((180 / Mathf.PI * h_C1p_C2p - 275) / 25, 2));

        float R_C = 2 * Mathf.Sqrt(Mathf.Pow(a_C1p_C2p, 7) / (Mathf.Pow(a_C1p_C2p, 7) + Mathf.Pow(25, 7)));

        float S_C = 1 + 0.045f * a_C1p_C2p;
        float S_H = 1 + 0.015f * a_C1p_C2p * T;

        float Lp_minus_Lp = dLp / (kL * S_C);
        float Cp_minus_Cp = dCp / (kC * S_C);
        float dHp_minus_dHp = dHp / (kH * S_H);

        float deltaE00 = Mathf.Sqrt(Mathf.Pow(Lp_minus_Lp, 2) + Mathf.Pow(Cp_minus_Cp, 2) + Mathf.Pow(dHp_minus_dHp, 2) + R_C * Cp_minus_Cp * dHp_minus_dHp);

        return deltaE00;
    }

    // Internal struct to hold LAB color values
    private struct ColorLAB
    {
        public float L;
        public float A;
        public float B;

        public ColorLAB(float l, float a, float b)
        {
            L = l;
            A = a;
            B = b;
        }
    }
}