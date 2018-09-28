﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheKoans
{
    [TestClass]
    public class AboutInheritance : KoanHelper
    {
        public class Dog
        {
            public string Name { get; set; }

            public Dog(string name)
            {
                Name = name;
            }

            // For a method/function to be overidden by sub-classes, it must be virtual.
            public virtual string Bark()
            {
                return "WOOF";
            }
        }

        public class Chihuahua : Dog
        {
            // The only way to "construct" a Dog is to give it a name. Since a 
            // Chihuahua 'is a Dog' it must conform to a public/protected
            // constructor. Since the only public/protected constructor for a 
            // dog requires a name, a public/protected constructor must also
            // require a Name.
            public Chihuahua(string name)
                : base(name)
            {
            }

            //Unless it doesn't. You have to call the base constructor at some point
            //with a name, but you don't have to have your class conform to that spec:
            public Chihuahua()
                : base("Ima Chihuahua")
            {
            }

            // For a Chihuahua to do something different than a regular "Dog"
            // when called to "Bark", the base class must be virtual and the
            // derived class must declare it as "override".
            public override string Bark()
            {
                return "yip";
            }

            // A derived class can have have methods/functions or properties
            // that are new behaviors altogether.
            public string Wag()
            {
                return "Happy";
            }
        }

        [TestMethod]
        public void SubclassesHaveTheParentAsAnAncestor()
        {
            Assert.IsTrue(typeof(Dog).IsAssignableFrom(typeof(Chihuahua)));
        }

        [TestMethod]
        public void AllClassesUltimatelyInheritFromAnObject()
        {
            Assert.IsTrue(typeof(object).IsAssignableFrom(typeof(Chihuahua)));
        }

        [TestMethod]
        public void SubclassesInheritBehaviorFromParentClass()
        {
            var chico = new Chihuahua("Chico");
            Assert.AreEqual("Chico", chico.Name);
        }

        [TestMethod]
        public void SubclassesAddNewBehavior()
        {
            var chico = new Chihuahua("Chico");
            Assert.AreEqual("Happy", chico.Wag());

            //We can search the public methods of an object 
            //instance like this:
            Assert.IsNotNull(chico.GetType().GetMethod("Wag"));

            //So we can show that the Wag method isn't on Dog. 
            //Proving you can't wag the dog. 
            var dog = new Dog("Fluffy");
            Assert.IsNull(dog.GetType().GetMethod("Wag"));
        }

        [TestMethod]
        public void SubclassesCanModifyExistingBehavior()
        {
            var chico = new Chihuahua("Chico");
            Assert.AreEqual("yip", chico.Bark());

            //Note that even if we cast the object back to a dog
            //we still get the Chihuahua's behavior. It truly
            //"is-a" Chihuahua
            Dog dog = chico as Dog;
            Assert.AreEqual("yip", dog.Bark());

            var fido = new Dog("Fido");
            Assert.AreEqual("WOOF", fido.Bark());
        }

        public class ReallyYippyChihuahua : Chihuahua
        {
            public ReallyYippyChihuahua(string name) : base(name) { }

            //It is possible to redefine behavior for classes where
            //the methods were not marked virtual - but it can really
            //get you if you aren't careful. For example:

            public new string Wag()
            {
                return "WAG WAG WAG!!";
            }

        }

        [TestMethod]
        public void SubclassesCanRedefineBehaviorThatIsNotVirtual()
        {
            ReallyYippyChihuahua suzie = new ReallyYippyChihuahua("Suzie");
            Assert.AreEqual("WAG WAG WAG!!", suzie.Wag());
        }

        [TestMethod]
        public void NewingAMethodDoesNotChangeTheBaseBehavior()
        {
            //This is vital to understand. In Koan 6, you saw that the Wag
            //method did what we defined in our class. But what happens
            //when we do this?
            Chihuahua bennie = new ReallyYippyChihuahua("Bennie");
            Assert.AreEqual("Happy", bennie.Wag());

            //That's right. The behavior of the object is dependent solely
            //on who you are pretending to be. Unlike when you override a
            //virtual method. Remember this in your path to enlightenment.

        }

        public class BullDog : Dog
        {
            public BullDog(string name) : base(name) { }
            public override string Bark()
            {
                return base.Bark() + ", GROWL";
            }
        }

        [TestMethod]
        public void SubclassesCanInvokeParentBehaviorUsingBase()
        {
            var ralph = new BullDog("Ralph");
            Assert.AreEqual("WOOF, GROWL", ralph.Bark());
        }

        public class GreatDane : Dog
        {
            public GreatDane(string name) : base(name) { }
            public string Growl()
            {
                return base.Bark() + ", GROWL";
            }
        }

        [TestMethod]
        public void YouCanCallBaseEvenFromOtherMethods()
        {
            var george = new BullDog("George");
            Assert.AreEqual("WOOF, GROWL", george.Bark());
        }

    }
}
