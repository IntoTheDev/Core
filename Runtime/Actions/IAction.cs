namespace ToolBox.Runtime.Actions
{
	public interface IAction
    	{
		void Act();
    	}

	public interface IAction<T>
	{
		void Act(T value);
	}
}
