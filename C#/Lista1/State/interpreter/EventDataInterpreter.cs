using System;
using State.@event;

namespace State.interpreter
{
    public interface EventDataInterpreter
    {
        EventData interpret(String message);
    }
}