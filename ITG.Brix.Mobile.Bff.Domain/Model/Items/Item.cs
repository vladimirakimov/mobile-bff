using ITG.Brix.Mobile.Bff.Domain.Internal;
using System.Collections.Generic;
using System.Linq;

namespace ITG.Brix.Mobile.Bff.Domain
{
    public class Item
    {
        public static readonly Item Source = new Item(ItemKey.Source, FilterKey.Source);
        public static readonly Item CustomerName = new Item(ItemKey.CustomerName, FilterKey.CustomerName);
        public static readonly Item TransportNumber = new Item(ItemKey.TransportNumber, FilterKey.TransportNumber);
        public static readonly Item LoadingPlace = new Item(ItemKey.LoadingPlace, FilterKey.LoadingPlace);
        public static readonly Item LoadingReference = new Item(ItemKey.LoadingReference, FilterKey.LoadingReference);

        public static readonly Item Site = new Item(ItemKey.Site, FilterKey.Site);
        public static readonly Item OperationalDepartment = new Item(ItemKey.OperationalDepartment, FilterKey.OperationalDepartment);
        public static readonly Item DockingZone = new Item(ItemKey.DockingZone, FilterKey.DockingZone);

        public static readonly Item LicensePlateTruck = new Item(ItemKey.LicensePlateTruck, FilterKey.LicensePlateTruck);
        public static readonly Item LicensePlateTrailer = new Item(ItemKey.LicensePlateTrailer, FilterKey.LicensePlateTrailer);

        public static readonly Item ContainerNumber = new Item(ItemKey.ContainerNumber, FilterKey.ContainerNumber);
        public static readonly Item ContainerLocation = new Item(ItemKey.ContainerLocation, FilterKey.ContainerLocation);
        public static readonly Item ContainerStackLocation = new Item(ItemKey.ContainerStackLocation, FilterKey.ContainerStackLocation);


        public static readonly Item SourceOrderId = new Item(ItemKey.SourceOrderId, FilterKey.SourceOrderId);
        public static readonly Item OperationType = new Item(ItemKey.OperationType, FilterKey.OperationType);
        public static readonly Item OperationGroup = new Item(ItemKey.OperationGroup, FilterKey.OperationGroup);
        public static readonly Item Operation = new Item(ItemKey.Operation, FilterKey.Operation);
        public static readonly Item UnitPlanning = new Item(ItemKey.UnitPlanning, FilterKey.UnitPlanning);
        public static readonly Item TypePlanning = new Item(ItemKey.TypePlanning, FilterKey.TypePlanning);

        public static readonly Item Reference1 = new Item(ItemKey.Reference1, FilterKey.Reference1);
        public static readonly Item Reference2 = new Item(ItemKey.Reference2, FilterKey.Reference2);
        public static readonly Item Reference3 = new Item(ItemKey.Reference3, FilterKey.Reference3);
        public static readonly Item Reference4 = new Item(ItemKey.Reference4, FilterKey.Reference4);
        public static readonly Item Reference5 = new Item(ItemKey.Reference5, FilterKey.Reference5);

        public static readonly Item ArdReference1 = new Item(ItemKey.ArdReference1, FilterKey.ArdReference1);
        public static readonly Item ArdReference2 = new Item(ItemKey.ArdReference2, FilterKey.ArdReference2);
        public static readonly Item ArdReference3 = new Item(ItemKey.ArdReference3, FilterKey.ArdReference3);
        public static readonly Item ArdReference4 = new Item(ItemKey.ArdReference4, FilterKey.ArdReference4);
        public static readonly Item ArdReference5 = new Item(ItemKey.ArdReference5, FilterKey.ArdReference5);
        public static readonly Item ArdReference6 = new Item(ItemKey.ArdReference6, FilterKey.ArdReference6);
        public static readonly Item ArdReference7 = new Item(ItemKey.ArdReference7, FilterKey.ArdReference7);
        public static readonly Item ArdReference8 = new Item(ItemKey.ArdReference8, FilterKey.ArdReference8);
        public static readonly Item ArdReference9 = new Item(ItemKey.ArdReference9, FilterKey.ArdReference9);
        public static readonly Item ArdReference10 = new Item(ItemKey.ArdReference10, FilterKey.ArdReference10);

        public static readonly Item ProductionSite = new Item(ItemKey.ProductionSite, FilterKey.ProductionSite);
        public static readonly Item DeliveryPlace = new Item(ItemKey.DeliveryPlace, FilterKey.DeliveryPlace);
        public static readonly Item BillOfLading = new Item(ItemKey.BillOfLading, FilterKey.BillOfLading);
        public static readonly Item BillOfLadingWeightNet = new Item(ItemKey.BillOfLadingWeightNet, FilterKey.BillOfLadingWeightNet);
        public static readonly Item BillOfLadingWeightGross = new Item(ItemKey.BillOfLadingWeightGross, FilterKey.BillOfLadingWeightGross);
        public static readonly Item CertificateOfOrigin = new Item(ItemKey.CertificateOfOrigin, FilterKey.CertificateOfOrigin);
        public static readonly Item CarrierBooked = new Item(ItemKey.CarrierBooked, FilterKey.CarrierBooked);
        public static readonly Item CarrierArrived = new Item(ItemKey.CarrierArrived, FilterKey.CarrierArrived);
        public static readonly Item TransportKind = new Item(ItemKey.TransportKind, FilterKey.TransportKind);
        public static readonly Item TransportType = new Item(ItemKey.TransportType, FilterKey.TransportType);
        public static readonly Item DriverWait = new Item(ItemKey.DriverWait, FilterKey.DriverWait);
        public static readonly Item Driver = new Item(ItemKey.Driver, FilterKey.Driver);

        public static readonly Item Railcar = new Item(ItemKey.Railcar, FilterKey.Railcar);
        public static readonly Item Seal1 = new Item(ItemKey.Seal1, FilterKey.Seal1);
        public static readonly Item Seal2 = new Item(ItemKey.Seal2, FilterKey.Seal2);
        public static readonly Item Seal3 = new Item(ItemKey.Seal3, FilterKey.Seal3);
        public static readonly Item WeighbridgeWeightNet = new Item(ItemKey.WeighbridgeWeightNet, FilterKey.WeighbridgeWeightNet);
        public static readonly Item WeighbridgeWeightGross = new Item(ItemKey.WeighbridgeWeightGross, FilterKey.WeighbridgeWeightGross);
        public static readonly Item ContainerFreeUntilOnTerminal = new Item(ItemKey.ContainerFreeUntilOnTerminal, FilterKey.ContainerFreeUntilOnTerminal);
        public static readonly Item ContainerFreeUntilOnTerminalCustomerAgreement = new Item(ItemKey.ContainerFreeUntilOnTerminalCustomerAgreement, FilterKey.ContainerFreeUntilOnTerminalCustomerAgreement);
        public static readonly Item Adr = new Item(ItemKey.Adr, FilterKey.Adr);

        public static readonly Item CustomsDocument = new Item(ItemKey.CustomsDocument, FilterKey.CustomsDocument);
        public static readonly Item CustomsDocumentNumber = new Item(ItemKey.CustomsDocumentNumber, FilterKey.CustomsDocumentNumber);
        public static readonly Item CustomsDocumentOffice = new Item(ItemKey.CustomsDocumentOffice, FilterKey.CustomsDocumentOffice);
        public static readonly Item CustomsDocumentDate = new Item(ItemKey.CustomsDocumentDate, FilterKey.CustomsDocumentDate);

        public static readonly Item ArrivalExpected = new Item(ItemKey.ArrivalExpected, FilterKey.ArrivalExpected);
        public static readonly Item ArrivalArrived = new Item(ItemKey.ArrivalArrived, FilterKey.ArrivalArrived);
        public static readonly Item ArrivalLatest = new Item(ItemKey.ArrivalLatest, FilterKey.ArrivalLatest);

        public static readonly Item LoadingDock = new Item(ItemKey.LoadingDock, FilterKey.LoadingDock);
        public static readonly Item EOrderPriority = new Item(ItemKey.EOrderPriority, FilterKey.EOrderPriority);
        public static readonly Item EOrderPriorityValue = new Item(ItemKey.EOrderPriorityValue, FilterKey.EOrderPriorityValue);
        public static readonly Item DispatchPriority = new Item(ItemKey.DispatchPriority, FilterKey.DispatchPriority);
        public static readonly Item DispatchTo = new Item(ItemKey.DispatchTo, FilterKey.DispatchTo);
        public static readonly Item DispatchComment = new Item(ItemKey.DispatchComment, FilterKey.DispatchComment);
        public static readonly Item Zone = new Item(ItemKey.Zone, FilterKey.Zone);
        public static readonly Item ProductOverview = new Item(ItemKey.ProductOverview, FilterKey.ProductOverview);
        public static readonly Item LotbatchOverview = new Item(ItemKey.LotbatchOverview, FilterKey.LotbatchOverview);
        public static readonly Item OperationalStatus = new Item(ItemKey.OperationalStatus, FilterKey.OperationalStatus);
        public static readonly Item OperationalOperant = new Item(ItemKey.OperationalOperant, FilterKey.OperationalOperant);

        public Item(ItemKey key, FilterKey filterKey)
        {
            if (object.Equals(key, null))
            {
                throw Error.ArgumentNull(string.Format("{0} can't be null.", nameof(key)));
            }

            if (object.Equals(filterKey, null))
            {
                throw Error.ArgumentNull(string.Format("{0} can't be null.", nameof(filterKey)));
            }

            Key = key;
            FilterKey = filterKey;
        }

        public ItemKey Key { get; }
        public FilterKey FilterKey { get; }

        public static string GetPath(ItemKey key)
        {
            var result = GetPath(key.Value);
            return result;
        }

        public static string GetPath(string key)
        {
            var result = List().Where(x => x.Key.Value == key).Select(s => s.FilterKey.Value).First();
            return result;
        }


        public static IEnumerable<Item> List()
        {
            return new[] {
                Source,
                CustomerName,
                TransportNumber,
                LoadingPlace,
                LoadingReference,
                Site,
                OperationalDepartment,
                DockingZone,
                LicensePlateTruck,
                LicensePlateTrailer,
                ContainerNumber,
                ContainerLocation,
                ContainerStackLocation,
                SourceOrderId,
                OperationType,
                OperationGroup,
                Operation,
                UnitPlanning,
                TypePlanning,
                Reference1,
                Reference2,
                Reference3,
                Reference4,
                Reference5,
                ArdReference1,
                ArdReference2,
                ArdReference3,
                ArdReference4,
                ArdReference5,
                ArdReference6,
                ArdReference7,
                ArdReference8,
                ArdReference9,
                ArdReference10,
                ProductionSite,
                DeliveryPlace,
                BillOfLading,
                BillOfLadingWeightNet,
                BillOfLadingWeightGross,
                CertificateOfOrigin,
                CarrierBooked,
                CarrierArrived,
                TransportKind,
                TransportType,
                DriverWait,
                Driver,
                Railcar,
                Seal1,
                Seal2,
                Seal3,
                WeighbridgeWeightNet,
                WeighbridgeWeightGross,
                ContainerFreeUntilOnTerminal,
                ContainerFreeUntilOnTerminalCustomerAgreement,
                Adr,
                CustomsDocument,
                CustomsDocumentNumber,
                CustomsDocumentOffice,
                CustomsDocumentDate,
                ArrivalExpected,
                ArrivalArrived,
                ArrivalLatest,
                LoadingDock,
                EOrderPriority,
                EOrderPriorityValue,
                DispatchPriority,
                DispatchTo,
                DispatchComment,
                Zone,
                ProductOverview,
                LotbatchOverview,
                OperationalStatus,
                OperationalOperant
            };
        }
    }
}
