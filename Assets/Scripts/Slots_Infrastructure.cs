public class Slots_Infrastructure {}

/*
    enum Slots_GameState

    Used by Slots_StateControl to determine actions.
    Represents game flow: STARTING -> SPINNING -> STOPPING (2x) -> FINISHING
*/
public enum Slots_GameState {
    STARTING,
    SPINNING,
    STOPPED_SPIN_1,
    STOPPED_SPIN_2,
    FINISHING
}