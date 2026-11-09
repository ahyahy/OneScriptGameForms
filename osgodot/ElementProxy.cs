using Godot;
using System;

public partial class ElementProxy : Node
{
	public Action<double> OnProcess;
	public Action OnReady;
	public Action<InputEvent> OnInput;
	public Vector2 mouseOldPosition = new Vector2();
	public bool isMouseOver = false;
	public bool mouseMoveSubscribed = false;
	public bool pressedSubscribed = false;
	public bool thisMouseEntered = false;
	public bool mouseEnteredSubscribed = false;
	public bool mouseExitedSubscribed = false;
	public bool buttonDownSubscribed = false;
	public bool buttonUpSubscribed = false;
	public bool focusEnteredSubscribed = false;
	public bool focusExitedSubscribed = false;
	public bool resizedSubscribed = false;
	public bool toggledSubscribed = false;

	public override void _Ready()
	{
		OnReady?.Invoke();
	}

	public override void _Process(double delta)
	{
		OnProcess?.Invoke(delta);
	}

	public override void _Input(InputEvent @event)
	{
		OnInput?.Invoke(@event);
	}
}
