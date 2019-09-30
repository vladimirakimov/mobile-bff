using ITG.Brix.Mobile.Bff.Domain.Internal;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Domain
{
    public class FilterKey
    {
        public static readonly FilterKey Source = new FilterKey("source");
        public static readonly FilterKey CustomerName = new FilterKey("customer");
        public static readonly FilterKey TransportNumber = new FilterKey("number");
        public static readonly FilterKey LoadingPlace = new FilterKey("loading-place");
        public static readonly FilterKey LoadingReference = new FilterKey("loading-reference");

        public static readonly FilterKey Site = new FilterKey("site");
        public static readonly FilterKey OperationalDepartment = new FilterKey("department");
        public static readonly FilterKey DockingZone = new FilterKey("dockingzone");

        public static readonly FilterKey LicensePlateTruck = new FilterKey("license-plate-truck");
        public static readonly FilterKey LicensePlateTrailer = new FilterKey("license-plate-trailer");

        public static readonly FilterKey ContainerNumber = new FilterKey("container-no");
        public static readonly FilterKey ContainerLocation = new FilterKey("container-loc");
        public static readonly FilterKey ContainerStackLocation = new FilterKey("container-st-loc");


        public static readonly FilterKey SourceOrderId = new FilterKey("src-order-entry");
        public static readonly FilterKey OperationType = new FilterKey("operation-type");
        public static readonly FilterKey OperationGroup = new FilterKey("operation-group");
        public static readonly FilterKey Operation = new FilterKey("operation");
        public static readonly FilterKey UnitPlanning = new FilterKey("unit-planning");
        public static readonly FilterKey TypePlanning = new FilterKey("type-planning");

        public static readonly FilterKey Reference1 = new FilterKey("ref1");
        public static readonly FilterKey Reference2 = new FilterKey("ref2");
        public static readonly FilterKey Reference3 = new FilterKey("ref3");
        public static readonly FilterKey Reference4 = new FilterKey("ref4");
        public static readonly FilterKey Reference5 = new FilterKey("ref5");

        public static readonly FilterKey ArdReference1 = new FilterKey("ard1");
        public static readonly FilterKey ArdReference2 = new FilterKey("ard2");
        public static readonly FilterKey ArdReference3 = new FilterKey("ard3");
        public static readonly FilterKey ArdReference4 = new FilterKey("ard4");
        public static readonly FilterKey ArdReference5 = new FilterKey("ard5");
        public static readonly FilterKey ArdReference6 = new FilterKey("ard6");
        public static readonly FilterKey ArdReference7 = new FilterKey("ard7");
        public static readonly FilterKey ArdReference8 = new FilterKey("ard8");
        public static readonly FilterKey ArdReference9 = new FilterKey("ard9");
        public static readonly FilterKey ArdReference10 = new FilterKey("ard10");

        public static readonly FilterKey ProductionSite = new FilterKey("prodsite");
        public static readonly FilterKey DeliveryPlace = new FilterKey("delivery-place");
        public static readonly FilterKey BillOfLading = new FilterKey("bol");
        public static readonly FilterKey BillOfLadingWeightNet = new FilterKey("bol-net");
        public static readonly FilterKey BillOfLadingWeightGross = new FilterKey("bol-gross");
        public static readonly FilterKey CertificateOfOrigin = new FilterKey("certorig");
        public static readonly FilterKey CarrierBooked = new FilterKey("carrier-booked");
        public static readonly FilterKey CarrierArrived = new FilterKey("carrier-arrived");
        public static readonly FilterKey TransportKind = new FilterKey("transport-kind");
        public static readonly FilterKey TransportType = new FilterKey("transport-type");
        public static readonly FilterKey DriverWait = new FilterKey("driver-wait");
        public static readonly FilterKey Driver = new FilterKey("driver");

        public static readonly FilterKey Railcar = new FilterKey("railcar");
        public static readonly FilterKey Seal1 = new FilterKey("seal1");
        public static readonly FilterKey Seal2 = new FilterKey("seal2");
        public static readonly FilterKey Seal3 = new FilterKey("seal3");
        public static readonly FilterKey WeighbridgeWeightNet = new FilterKey("weighbridge-net");
        public static readonly FilterKey WeighbridgeWeightGross = new FilterKey("weighbridge-gross");
        public static readonly FilterKey ContainerFreeUntilOnTerminal = new FilterKey("fuot");
        public static readonly FilterKey ContainerFreeUntilOnTerminalCustomerAgreement = new FilterKey("fuotcustomer");
        public static readonly FilterKey Adr = new FilterKey("adr");

        public static readonly FilterKey CustomsDocument = new FilterKey("customsdoc");
        public static readonly FilterKey CustomsDocumentNumber = new FilterKey("customsdoc-no");
        public static readonly FilterKey CustomsDocumentOffice = new FilterKey("customsdoc-office");
        public static readonly FilterKey CustomsDocumentDate = new FilterKey("customsdoc-date");

        public static readonly FilterKey ArrivalExpected = new FilterKey("arrival-expected");
        public static readonly FilterKey ArrivalArrived = new FilterKey("arrival-arrived");
        public static readonly FilterKey ArrivalLatest = new FilterKey("arrival-latest");

        public static readonly FilterKey LoadingDock = new FilterKey("loading-dock");
        public static readonly FilterKey EOrderPriority = new FilterKey("eo-priority");
        public static readonly FilterKey EOrderPriorityValue = new FilterKey("eo-priority-value");
        public static readonly FilterKey DispatchPriority = new FilterKey("dispatch-priority");
        public static readonly FilterKey DispatchTo = new FilterKey("dispatch-to");
        public static readonly FilterKey DispatchComment = new FilterKey("dispatch-comment");
        public static readonly FilterKey Zone = new FilterKey("zone");
        public static readonly FilterKey ProductOverview = new FilterKey("product-overview");
        public static readonly FilterKey LotbatchOverview = new FilterKey("lotbatch-overview");

        public static readonly FilterKey OperationalStatus = new FilterKey("operationalstatus");
        public static readonly FilterKey OperationalOperant = new FilterKey("operationaloperant");

        public FilterKey(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw Error.Argument(string.Format("{0} can't be empty.", nameof(value)));
            }

            Value = value;
        }

        public string Value { get; }

        public static IEnumerable<FilterKey> List()
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
