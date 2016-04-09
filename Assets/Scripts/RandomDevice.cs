using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.Assertions;

public class RandomDevice {

	public static int NextInt(int minValue = 0, int maxValue = int.MaxValue)
    {
        Assert.IsTrue(minValue < maxValue);
        byte[] random = new byte[4];
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        rng.GetBytes(random);

        int value = 0;

        for(int i=0; i < random.Length; ++i)
        {
            value |= random[i] << (4 * i);
        }

        float scaled = value / int.MaxValue;

        int result = (int)((maxValue - minValue + 1) * scaled + minValue);

        Assert.IsTrue(result >= minValue && result < maxValue);

        return result;
    }
}
