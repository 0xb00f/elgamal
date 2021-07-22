using System;
using System.Numerics;
using System.Text;

namespace elgamal
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "Now is the winter of our discontent.";
	    byte[] m = Encoding.ASCII.GetBytes(message);
	    BigInteger mod = BigInteger.Parse("96398551441758641432498106966804152150608120353342563371292746847062383495952333903880077300033579628752765930551257877420508008817301766932673738933713818991130871127607526293923392284520225229071937");
	    BigInteger g = BigInteger.Parse("397589");
	    ElGamalCipher elg = new ElGamalCipher(mod, g);
	    BigInteger c1, c2;
	    (c1,c2) = elg.Encrypt(m);
	    BigInteger result = elg.Decrypt(c1,c2);
	    Console.WriteLine("result is:\n{0}",Encoding.ASCII.GetString(result.ToByteArray()));
        }
    }
}
