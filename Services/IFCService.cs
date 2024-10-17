using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using System.Collections.Generic;

namespace HKLS_App.Services
{
    public class IFCService
    {
        public List<string> GetComponentInfoFromIFC(string ifcFilePath, string componentIdentifier)
        {
            var componentInfo = new List<string>();

            using (var model = IfcStore.Open(ifcFilePath))
            {
                foreach (var entity in model.Instances.OfType<IIfcProduct>())
                {
                    if (entity.GlobalId == componentIdentifier)
                    {
                        componentInfo.Add($"Name: {entity.Name}");
                        componentInfo.Add($"Description: {entity.Description}");
                        componentInfo.Add($"Location: {entity.ObjectPlacement}");
                        break;
                    }
                }
            }

            return componentInfo;
        }
    }
}
