using Logger.Layouts;

namespace Logger.Core.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string typeName)
        {
            ILayout layout = null;

            try
            {
                Type type = Type.GetType("Logger.Layouts." + typeName);

                layout = (ILayout)Activator.CreateInstance(type);
            }
            catch (Exception)
            {
                throw new ArgumentException($"{typeName} is invalid Layout type.");
            }

            return layout;
        }
    }
}
