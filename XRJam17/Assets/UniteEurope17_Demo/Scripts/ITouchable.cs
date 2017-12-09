public interface ITouchable
{
	void Activate();
	void Focus();
	void Deactivate();
	string Description { get; }
}
