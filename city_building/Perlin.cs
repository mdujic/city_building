using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace city_building
{
    internal class Perlin
    {
        // source: http://adrianb.io/2014/08/09/perlinnoise.html
        public Perlin() { }

        private static readonly int[] permutation = { 151,160,137,91,90,15,                 // Hash lookup table as defined by Ken Perlin.  This is a randomly
            131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,    // arranged array of all numbers from 0-255 inclusive.
            190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
            88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
            102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
            135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
            5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
            223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
            129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
            251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
            49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
            138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
        };

        private static readonly int[] p;                                                    // Doubled permutation to avoid overflow

        static Perlin()
        {
            p = new int[512];
            for (int x = 0; x < 512; x++)
            {
                p[x] = permutation[x % 256];
            }
        }

        public static double fade(double t)
        {
            // Fade function as defined by Ken Perlin.  This eases coordinate values
            // so that they will ease towards integral values.  This ends up smoothing
            // the final output.
            return t * t * t * (t * (t * 6 - 15) + 10);         // 6t^5 - 15t^4 + 10t^3
        }

        public static double grad(int hash, double x, double y)
        {
            switch (hash & 3)
            {
                case 0: return x + y;
                case 1: return -x + y;
                case 2: return x - y;
                case 3: return -x - y;
                default: return 0; // never happens
            }
        }

        // Linear Interpolate
        public static double lerp(double a, double b, double x)
        {
            return a + x * (b - a);
        }

        public double perlin(double x, double y)
        {
            int xi = (int)x & 255;  // Calculate the "unit cube" that the point asked will be located in
            int yi = (int)y & 255;  // The left bound is ( |_x_|,|_y_|,|_z_| ) and the right bound is that
                                    // plus 1.  Next we calculate the location (from 0.0 to 1.0) in that cube.
            double xf = x - (int)x;
            double yf = y - (int)y;

            double u = fade(xf);
            double v = fade(yf);

            int aa, ab, ba, bb;
            aa = p[p[xi] + yi];
            ab = p[p[xi] + yi + 1];
            ba = p[p[xi + 1] + yi];
            bb = p[p[xi + 1] + yi + 1];

            double x1, x2;
            x1 = lerp(grad(aa, xf, yf),           // The gradient function calculates the dot product between a pseudorandom
                        grad(ba, xf - 1, yf),             // gradient vector and the vector from the input coordinate to the 8
                        u);                                     // surrounding points in its unit cube.
            x2 = lerp(grad(ab, xf, yf - 1),           // This is all then lerped together as a sort of weighted average based on the faded (u,v,w)
                        grad(bb, xf - 1, yf - 1),             // values we made earlier.
                          u);

            return (lerp(x1, x2, v)+1)/2;
        }

        // the generation bit
        public class Wave
        {
            public double seed { get; set; }
            public double frequency { get; set; }
            public double amplitude { get; set; }

            public Wave(double seed, double frequency, double amplitude)
            {
                this.seed = seed;
                this.frequency = frequency;
                this.amplitude = amplitude;
            }
        }

        public class PerlinParameters
        {
            public double scale { get; set; }
            public double offsetX { get; set; }
            public double offsetY { get; set; }
            public List<Wave> heightWaves { get; set; }
            public List<Wave> heatWaves { get; set; }
            public PerlinParameters(double scale, double offsetX, double offsetY, 
                List<Wave> heightWaves, List<Wave> heatWaves)
            {
                this.scale = scale;
                this.offsetX = offsetX;
                this.offsetY = offsetY;
                this.heightWaves = heightWaves;
                this.heatWaves = heatWaves;
            }
        }

        public static double GetPseudoDoubleWithinRange(double lowerBound, double upperBound)
        {
            var random = new Random();
            var rDouble = random.NextDouble();
            var rRangeDouble = rDouble * (upperBound - lowerBound) + lowerBound;
            return rRangeDouble;
        }

        public PerlinParameters perlinParameters = new PerlinParameters(
            2,
            0.0,
            0.0,
            new List<Wave>
            {
                new Wave(GetPseudoDoubleWithinRange(0, 512), 0.05, 1),
                new Wave(GetPseudoDoubleWithinRange(0, 512), 0.1, 0.5)
            },
            new List<Wave>
            {
                new Wave(GetPseudoDoubleWithinRange(0, 512), 0.04, 1),
                new Wave(GetPseudoDoubleWithinRange(0, 512), 0.02, 0.5)
            }
            );

        public class BiomePreset
        {
            public string name { get; set; }
            public double minHeight { get; set; }
            public double minHeat { get; set; }
            public BiomePreset(string name, double minHeight, double minHeat)
            {
                this.name = name;
                this.minHeight = minHeight;
                this.minHeat = minHeat;
            }
        }

        public List<BiomePreset> biomes = new List<BiomePreset>{
            new BiomePreset("voda", 0, 0.3),
            new BiomePreset("polje", 0.25, 0.3),
            new BiomePreset("šuma", 0.35, 0.5),
            new BiomePreset("stijena", 0.55, 0.5)
        };

        public class BiomeTempData
        {
            public BiomePreset biome;
            public BiomeTempData(BiomePreset preset)
            {
                biome = preset;
            }

            public double GetDiffValue(double height, double heat)
            {
                return (height - biome.minHeight) + (heat - biome.minHeat);
            }
        }

        public BiomePreset GetBiome(double height, double heat)
        {
            List<BiomeTempData> biomeTemp = new List<BiomeTempData>();
            foreach (BiomePreset biome in biomes)
            {
                if (height > biome.minHeight && heat > biome.minHeat)
                {
                    biomeTemp.Add(new BiomeTempData(biome));
                }
            }

            double curVal = 0.0;
            BiomePreset biomeToReturn = null;

            foreach (BiomeTempData biome in biomeTemp)
            {
                if (biomeToReturn == null)
                {
                    biomeToReturn = biome.biome;
                    curVal = biome.GetDiffValue(height,  heat);
                }
                else
                {
                    if (biome.GetDiffValue(height, heat) < curVal)
                    {
                        biomeToReturn = biome.biome;
                        curVal = biome.GetDiffValue(height, heat);
                    }
                }
            }
            if (biomeToReturn == null)
                biomeToReturn = biomes[0];

            return biomeToReturn;
        }

        public double[,] PerlinNoiseMap(int velicina, List<Wave> waves)
        {
            // source: https://gamedevacademy.org/procedural-2d-maps-unity-tutorial/
            // create the noise map
            double[,] noiseMap = new double[velicina, velicina];

            Perlin p = new Perlin();

            // loop through each element in the noise map
            for (int x = 0; x < velicina; ++x)
            {
                for (int y = 0; y < velicina; ++y)
                {
                    // calculate the sample positions
                    double samplePosX = x * perlinParameters.scale + perlinParameters.offsetX;
                    double samplePosY = y * perlinParameters.scale + perlinParameters.offsetY;
                    double normalization = 0.0;
                    // loop through each wave
                    foreach (Wave wave in waves)
                    {
                        // sample the perlin noise taking into consideration amplitude and frequency
                        noiseMap[x, y] += wave.amplitude * p.perlin(samplePosX * wave.frequency + wave.seed, samplePosY * wave.frequency + wave.seed);
                        normalization += wave.amplitude;
                    }
                    // normalize the value
                    noiseMap[x, y] /= normalization;
                }
            }

            return noiseMap;
        }
    }
}
