/*
    Possible states of the slot machine's flow

    STARTING = 0
    SPINNING = 1
    STOPPED_SPIN_1 = 2
    STOPPED_SPIN_2 = 3
    FINISHING = 4
*/
public enum Slots_GameState {
    STARTING,
    SPINNING,
    STOPPED_SPIN_1,
    STOPPED_SPIN_2,
    FINISHING
}