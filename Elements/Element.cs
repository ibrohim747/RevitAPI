using RevitAPI;
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

        // ─────────────────────────── Constructor ───────────────────────────

        protected Element(int id, string name, object document, object category, Location location)
        {
            Id = id;
            Name = name;
            Document = document as Document
                       ?? throw new ArgumentNullException(nameof(document));
            Category = category as Category
                       ?? throw new ArgumentNullException(nameof(category));

            Parameters = new ParameterSet();
            Location = location;
        }

        // ──────────────────────────── Lifecycle ────────────────────────────

        /// <summary>
        /// Удаляет элемент из документа.
        /// После удаления Id сбрасывается в -1.
        /// </summary>
        public void Delete()
        {
        }

        /// <summary>Закрепляет элемент (запрещает перемещение).</summary>
        public void Pin()
        {
            if (Pinned)
                return;

            Pinned = true;
        }

        /// <summary>Открепляет элемент (разрешает перемещение).</summary>
        public void Unpin()
        {
            if (!Pinned)
                return;

            Pinned = false;
        }

        // ──────────────────────────── Materials ────────────────────────────

        /// <summary>
        /// Возвращает набор идентификаторов материалов элемента.
        /// </summary>
        /// <param name="returnPaintMaterials">
        ///   true  — вернуть также материалы покраски;
        ///   false — только конструктивные материалы.
        /// </param>
        public ICollection<ElementId> GetMaterialIds(bool returnPaintMaterials)
        {
            if (Parameters == null)
                return Array.Empty<ElementId>();

            return null;
        }

        /// <summary>
        /// Возвращает площадь, занятую материалом на поверхности элемента.
        /// </summary>
        public double GetMaterialArea(ElementId materialId, bool usePaintMaterial)
        {
            if (materialId == null)
                throw new ArgumentNullException(nameof(materialId));

            return 0.0;
        }

        /// <summary>
        /// Возвращает объём, занятый материалом внутри элемента.
        /// </summary>
        public double GetMaterialVolume(ElementId materialId)
        {
            if (materialId == null)
                throw new ArgumentNullException(nameof(materialId));

            return 0.0;
        }

        // ─────────────────────────── Parameters ────────────────────────────

        /// <summary>
        /// Находит параметр по идентификатору типа (ForgeTypeId).
        /// </summary>
        public Parameter GetParameter(ForgeTypeId parameterTypeId)
        {
            return null;
        }

        /// <summary>
        /// Возвращает все параметры с указанным именем.
        /// </summary>
        public IList<Parameter> GetParameters(string name)
        {
            return null;
        }

        // ──────────────────────────── Type / Id ────────────────────────────

        /// <summary>
        /// Возвращает ElementId типа элемента (ElementType).
        /// Если тип не назначен, возвращает ElementId.InvalidElementId.
        /// </summary>
        public ElementId GetTypeId()
        {
            // Тип хранится в именованном параметре "TYPE_ID"
            return RevitDocumentSimulator.Example_Return_For_Delete();
        }

        /// <summary>
        /// Проверяет, совпадают ли два ElementId.
        /// </summary>
        public bool Equals(ElementId first, ElementId second)
        {
            if (first == null && second == null) return true;
            if (first == null || second == null) return false;

            //return first.IntegerValue == second.IntegerValue;
            return false;
        }

        // ──────────────────────────── Phase ────────────────────────────────

        /// <summary>
        /// Возвращает статус элемента относительно заданной фазы.
        /// </summary>
        public ElementOnPhaseStatus GetPhaseStatus(ElementId phaseId)
        {
            if (phaseId == null)
                throw new ArgumentNullException(nameof(phaseId));

            // Элемент создан в этой фазе

            // Элемент создан в более ранней фазе — он существующий

            // Элемент ещё не существует в данной фазе
            return null;
        }

        // ──────────────────────────── Visibility ───────────────────────────

        /// <summary>
        /// Возвращает true, если элемент скрыт в указанном виде.
        /// </summary>
        public bool IsHidden(View pView)
        {
            if (pView == null)
                throw new ArgumentNullException(nameof(pView));

            return false;
        }

        /// <summary>
        /// Возвращает true, если элемент является типом (ElementType),
        /// а не экземпляром.
        /// </summary>
        public bool GetType()
        {
            return this is ElementType;
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
        GetMonitoredLinkElementIds
        GetMonitoredLocalElementIds
        GetOrderedParameters
        GetParameterFormatOptions
        GetSubelements
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
