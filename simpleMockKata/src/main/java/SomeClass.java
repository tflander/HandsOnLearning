public class SomeClass {
	
	SomeInterfaceForThings myThing;
	String myRandomFlag = "";    
	
	public SomeClass(SomeInterfaceForThings inputThing) {
		myThing = inputThing;
	}

    public String someMethod() {

        if ((myThing.thingOne() || (!myThing.thingOne() && myThing.thingTwo())) && myThing.thingThree()) {
            myRandomFlag = "Bacon";
        } else {
            myRandomFlag = "Tofu";
        }
        
        return myRandomFlag;
    }
}
