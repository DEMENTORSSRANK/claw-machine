public class FixedJoystick : Joystick
{
    public static bool Touching;
    
    private Manager_ClawMovement _manager;

    private void Awake()
    {
        _manager = FindObjectOfType<Manager_ClawMovement>();
    }

    private void Update()
    {
        _manager.UI_MoveClawDown_Off();
        _manager.UI_MoveClawUp_Off();
        _manager.UI_MoveClawLeft_Off();
        _manager.UI_MoveClawRight_Off();
        if (Horizontal == 1) _manager.UI_MoveClawRight();
        if (Horizontal == -1) _manager.UI_MoveClawLeft();
        if (Vertical == 1) _manager.UI_MoveClawUp();
        if (Vertical == -1) _manager.UI_MoveClawDown();
    }
}