namespace Wokarol
{
	internal interface IInteractible
	{
		string InteractionText { get; }
		float InteractionDistanceMultiplier { get; }

		void Interact ();
	}
}