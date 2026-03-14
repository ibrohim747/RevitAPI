using RevitAPI.Document;
using RevitAPI.Geometry;
using RevitAPI.Interfaces;
using RevitAPI.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI.Elements
{
    public abstract class Element : IElement
    {
        public int Id { get; protected set; }  //0
        public virtual string Name { get; set; }  //0
        public Document Document { get; protected set; }  //0
        public Category Category { get; protected set; }  //0
        public ParameterSet Parameters { get; protected set; }  //0
        public virtual Location Location { get; set; }  //protected set;
        public bool Pinned { get; set; }  //1
        public ElementId AssemblyInstanceId { get; }  //The id of the assembly instance to which the element belongs.
        public ElementId CreatedPhaseId { get; set; } //0
        public ElementId GroupId { get; }  //0
        public ElementId LevelId { get; }  //0
        public ElementId OwnerViewId { get; } //0
        public WorksetId WorksetId { get; }  //0

        /**
        BoundingBox
        DemolishedPhaseId
        DesignOption
        Geometry
        IsTransient
        IsValidObject
        Parameter Guid
        BuiltInParameter
        Definition
        ParametersMap
        UniqueId
        VersionGuid
        ViewSpecific
        */

        //-----------------------------------------------------------Methods

        protected Element(int id, string name, object document, object category)
        {
            Id = id;
            Name = name;
            Document = document;
            Category = category;
            // Инициализация параметров и местоположения
        }

        public void Delete()
        {
            // Логика удаления элемента
        }

        public void Pin()
        {
            // Логика закрепления элемента
        }

        public void Unpin()
        {
            // Логика открепления элемента
        }

        public ICollection<ElementId> GetMaterialIds(bool returnPaintMaterials)
        {
            return null;  //The set of material ids.
        }

        public IList<Parameter> GetParameters(string name) 
        {
            return null;  //A collection containing the parameters having the same given parameter name.
        }

        public ElementId GetTypeId()
        {
            return null; //return Id the type
        }

        /*
        ArePhasesModifiable
        CanBeHidden
        CanBeLocked
        CanDeleteSubelement
        CanHaveAnalyticalModel
        CanHaveTypeAssigned
        CanHaveTypeAssigned(Document, ICollection ElementId )
        ChangeTypeId(ElementId)
        ChangeTypeId(Document, ICollection ElementId , ElementId)
        DeleteEntity
        DeleteSubelement
        DeleteSubelements
        Dispose
        Equals
        GetAnalyticalModel
        GetAnalyticalModelId
        GetChangeTypeAny
        GetChangeTypeElementAddition
        GetChangeTypeElementDeletion
        GetChangeTypeGeometry
        GetChangeTypeParameter(ElementId)
        GetChangeTypeParameter(Parameter)
        GetDependentElements
        GetEntity
        GetEntitySchemaGuids
        GetExternalFileReference
        GetExternalResourceReference
        GetExternalResourceReferences
        GetGeneratingElementIds
        GetGeometryObjectFromReference
        GetHashCode
        GetMaterialArea
        GetMaterialVolume
        GetMonitoredLinkElementIds
        GetMonitoredLocalElementIds
        GetOrderedParameters
        GetParameterFormatOptions
        GetParameters
        GetPhaseStatus
        GetSubelements
        GetType
        GetTypeId
        GetValidTypes
        GetValidTypes(Document, ICollection ElementId )
        HasPhases
        IsExternalFileReference
        IsHidden
        IsMonitoringLinkElement
        IsMonitoringLocalElement
        IsPhaseCreatedValid
        IsPhaseDemolishedValid
        IsValidType(ElementId)
        IsValidType(Document, ICollection ElementId , ElementId)
        LookupParameter
        RefersToExternalResourceReference
        RefersToExternalResourceReferences
        SetEntity
        ToString
        */
    }
}
