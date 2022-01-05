namespace Aplicacion.IoC
{
    using StructureMap;

    public class StructureMapFilterProvider
    {
        private readonly IContainer container;
        public StructureMapFilterProvider(IContainer container)
        {
            this.container = container;
        }
    }
}
