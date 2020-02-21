using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloadasProject.Tesztek
{
    [TestFixture]
    class Teszt
    {
        
        [TestCase]
        public void EloadasHibas()
        {

            var teszt = new Eloadas(2,2);
            Assert.AreEqual(4, teszt.SzabadHelyek, "A férőhelyek száma hibás");
            
        }
        [TestCase]
        public void EloadasHibasOutOfRange()
        {
            var teszt = new Eloadas(5, 4);
            Assert.AreEqual(20, teszt.SzabadHelyek, "A férőhelyek száma hibás");
        }

        [TestCase]
        public void EloadasFoglalasiTesztNull()
        {
            var test = new Eloadas(3, 3);
            test.Lefoglal();
            Assert.AreNotEqual(null, test.Foglalt(2, 3), "A bool paraméter null");
        }

        [TestCase]
        public void EloadasHelyFoglalasutanAHelyekSzamaCsokken()
        {
            var teszt = new Eloadas(4, 4);
            teszt.Lefoglal();
            Assert.AreEqual(0, teszt.SzabadHelyek, "A szabad helyek nem csökkentek");
        }
        
        [TestCase]
        public void EloadasTeli()
        {
            var teszt = new Eloadas(4, 4);
            Assert.IsFalse(teszt.Teli, "Az előadás teli");
            for (int i = 0; i < 16; i++)
            {
                teszt.Lefoglal();
            }
            teszt.Lefoglal();
            Assert.IsTrue(teszt.Teli, "Teli előadás nincs teli");
        }
        
        [TestCase]
        public void EloadasHelyekSzamaLehetNegativ()
        {
            Assert.Throws<ArgumentException>(() => {
                var teszt = new Eloadas(-1,0);
            });
        }
        
        [TestCase]
        public void EloadasHelyLefoglal()
        {
            var teszt = new Eloadas(1,3);
            teszt.Lefoglal();
            teszt.Lefoglal();
            teszt.Lefoglal();
            Assert.AreEqual(true, teszt.Teli, "Teli előadás nincs teli");
        }

        [TestCase]
        public void EloadasHelyekSzamaNemNegativ()
        {
            var teszt = new Eloadas(5, 5);
            Assert.Greater(teszt.SzabadHelyek, -1, "A férőhelyek száma hibás");
        }

        [TestCase]
        public void EloadasLefoglaltTesztNull()
        {
            var teszt = new Eloadas(4, 4);
            teszt.Lefoglal();
            Assert.AreNotEqual(null, teszt.Foglalt(2, 3), "A bool paraméter null");
        }

        [TestCase]
        public void EloadasTeliNull()
        {
            var teszt = new Eloadas(6, 6);
            Assert.AreNotEqual(null, teszt.Teli, "A bool paraméter null");
        }



    }
}
