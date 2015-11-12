//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using State.appliance;

//namespace UnitTesty.StateTest.command
//{
//    [TestClass]
//    public class EventTest {

//    protected Appliance clock;
//    protected Appliance toaster;
//    protected Appliance mixer;
//    protected Appliance air;

//    @Test
//    public void testExecuteEvent() throws CouldNotExecuteCommandException, ApplianceCommunicationException {
//        Event event = createEvent();
//        event.execute();
//        verify(clock).start();

//        verify(toaster).turnOn();
//        verify(clock).start();

//        verify(air).turnOn();
//        verify(air).start();

//        verify(mixer).turnOn();
//        verify(mixer).start();

//    }

//    /**
//     * @return
//     */
//    private Event createEvent() {

//        // Mocked apliances

//        clock = mock(Appliance.class);
//        toaster = mock(Appliance.class);

//        mixer = mock(Appliance.class);

//        air = mock(Appliance.class);
//        Command startAlarmClock = new StartApplianceCommand(clock);

//        Command turnToasterOn = new TurnOnApplianceCommand(toaster);
//        Command startToaster = new StartApplianceCommand(toaster);

//        Command turnAirConditionerOn = new TurnOnApplianceCommand(air);
//        Command startAirConditioner = new StartApplianceCommand(air);

//        Command turnMixerOn = new TurnOnApplianceCommand(mixer);
//        Command startMixer = new StartApplianceCommand(mixer);

//        return new Event().with(startAlarmClock, turnToasterOn, startToaster, turnAirConditionerOn, startAirConditioner, turnMixerOn, startMixer);
//    }
//}
//}
