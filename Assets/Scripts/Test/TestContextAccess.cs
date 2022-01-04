using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Test
{
    public class TestContextAccess
    {

        private IMemberWrapper members;
        private MemberWrapperNoInterface members2;
        private MemeberWrapperNoInterfacePublicMembers members3;
        private TestState state;

        TestContextAccess()
        {
            members = new MemberWrapper();
            members2 = new MemberWrapperNoInterface();
            members3 = new MemeberWrapperNoInterfacePublicMembers();
            state = new TestState();

        }

        private interface IMemberWrapper
        {
            public TestState state { set; get; }
        }

        private class MemberWrapper : IMemberWrapper
        {
            TestState IMemberWrapper.state { set; get; }
        }
        private class MemberWrapperNoInterface
        {
            TestState state { set; get; }
            
        }

        private class MemeberWrapperNoInterfacePublicMembers
        {
            public TestState state { set; get; }
        }

        private class TestState
        {
            TestContextAccess context;

            public void test()
            {
                TestState o = context.members.state; //private interface allows nested classees to access to members in nested private class
                                                     //TestState o2 = context.members2.state;//ERROR: private class prevents access to members in nested private class

                /*ERROR:"Severity	Code	Description	Project	File	Line	Suppression State
                    Error CS0122  'TestContextAccess.MemberWrapperNoInterface.state' is inaccessible due to its protection level 
                Assembly - CSharp C: \Users\Brandon\unityProjects\HollowKnight\Assets\Scripts\Test\testContextAccess.cs    43  Active
                "
                */

                o = context.members3.state;//private nested class gives other nested classes access to public members
                o = o.context.state;
            }
        }
    }

    class TestAccessInnerMembers
    {
        public void test()
        {
            //TestContextAccess o;
            //o.members;//ERROR: private interface and class  prevents outside access to members
            //o.members2//ERORR: private class prevents outside access
            //o.member3;//ERROR; private member access
            //
   
        }
    }
}
