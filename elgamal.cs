using System;
using System.Numerics;

namespace elgamal 
{
	public class ElGamalCipher
	{
		// attributes
		private BigInteger modulus;
		private BigInteger order;
		private BigInteger gen;
		private BigInteger h;
		private BigInteger x;
		// constructor
		public ElGamalCipher(BigInteger prime, BigInteger g)
		{
			this.modulus = prime;
			this.order = prime - new BigInteger(1);
			this.gen = g;
			this.x = NewRandomValue();
			this.h = BigInteger.ModPow(g,this.x,prime); 
		}
		// TODO : public key getter

		// encryption
		public (BigInteger,BigInteger) Encrypt(byte[] message)
		{
			BigInteger m = new BigInteger(message);
			BigInteger y = NewRandomValue();
			BigInteger s = BigInteger.ModPow(this.h,y,this.modulus);
			BigInteger c1 = BigInteger.ModPow(this.gen,y,this.modulus);
			BigInteger c2 = BigInteger.Multiply(m,s) % this.modulus;
		
			return (c1,c2);
		}
		// decryption
		public BigInteger Decrypt(BigInteger c1, BigInteger c2)
		{
			BigInteger s = BigInteger.ModPow(c1,this.x,this.modulus);
			BigInteger s_inverse = BigInteger.ModPow(c1,this.order - this.x,this.modulus);

			return BigInteger.Multiply(c2,s_inverse) % this.modulus;
		}
		// new random value - naive method
		private BigInteger NewRandomValue()
		{
			Random rand = new Random();
			Byte[] barr = new Byte[this.modulus.GetByteCount()];
			rand.NextBytes(barr);
			barr[barr.Length-1] = 0;
			return new BigInteger(barr);
		}

	}
}
