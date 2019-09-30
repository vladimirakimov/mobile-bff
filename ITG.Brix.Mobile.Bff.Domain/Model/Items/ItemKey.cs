using ITG.Brix.Mobile.Bff.Domain.Internal;
using System.Collections.Generic;

namespace ITG.Brix.Mobile.Bff.Domain
{
    public class ItemKey
    {
        public static readonly ItemKey Source = new ItemKey("#source");
        public static readonly ItemKey CustomerName = new ItemKey("#customer");
        public static readonly ItemKey TransportNumber = new ItemKey("#transport_number");
        public static readonly ItemKey LoadingPlace = new ItemKey("#loading_place");
        public static readonly ItemKey LoadingReference = new ItemKey("#loading_reference");

        public static readonly ItemKey Site = new ItemKey("#site");
        public static readonly ItemKey OperationalDepartment = new ItemKey("#operational_department");
        public static readonly ItemKey DockingZone = new ItemKey("#dockingzone");

        public static readonly ItemKey LicensePlateTruck = new ItemKey("#license_plate_truck");
        public static readonly ItemKey LicensePlateTrailer = new ItemKey("#license_plate_trailer");

        public static readonly ItemKey ContainerNumber = new ItemKey("#container_number");
        public static readonly ItemKey ContainerLocation = new ItemKey("#container_location");
        public static readonly ItemKey ContainerStackLocation = new ItemKey("#container_stacklocation");


        public static readonly ItemKey SourceOrderId = new ItemKey("#source_order_id");
        public static readonly ItemKey OperationType = new ItemKey("#operation_type");
        public static readonly ItemKey OperationGroup = new ItemKey("#operation_group");
        public static readonly ItemKey Operation = new ItemKey("#operation");
        public static readonly ItemKey UnitPlanning = new ItemKey("#unit_planning");
        public static readonly ItemKey TypePlanning = new ItemKey("#type_planning");

        public static readonly ItemKey Reference1 = new ItemKey("#reference1");
        public static readonly ItemKey Reference2 = new ItemKey("#reference2");
        public static readonly ItemKey Reference3 = new ItemKey("#reference3");
        public static readonly ItemKey Reference4 = new ItemKey("#reference4");
        public static readonly ItemKey Reference5 = new ItemKey("#reference5");

        public static readonly ItemKey ArdReference1 = new ItemKey("#ard_reference1");
        public static readonly ItemKey ArdReference2 = new ItemKey("#ard_reference2");
        public static readonly ItemKey ArdReference3 = new ItemKey("#ard_reference3");
        public static readonly ItemKey ArdReference4 = new ItemKey("#ard_reference4");
        public static readonly ItemKey ArdReference5 = new ItemKey("#ard_reference5");
        public static readonly ItemKey ArdReference6 = new ItemKey("#ard_reference6");
        public static readonly ItemKey ArdReference7 = new ItemKey("#ard_reference7");
        public static readonly ItemKey ArdReference8 = new ItemKey("#ard_reference8");
        public static readonly ItemKey ArdReference9 = new ItemKey("#ard_reference9");
        public static readonly ItemKey ArdReference10 = new ItemKey("#ard_reference10");

        public static readonly ItemKey ProductionSite = new ItemKey("#production_site");
        public static readonly ItemKey DeliveryPlace = new ItemKey("#delivery_place");
        public static readonly ItemKey BillOfLading = new ItemKey("#bill_of_lading");
        public static readonly ItemKey BillOfLadingWeightNet = new ItemKey("#bill_of_lading_weight_net");
        public static readonly ItemKey BillOfLadingWeightGross = new ItemKey("#bill_of_lading_weight_gross");
        public static readonly ItemKey CertificateOfOrigin = new ItemKey("#certificate_of_origin");
        public static readonly ItemKey CarrierBooked = new ItemKey("#carrier_booked");
        public static readonly ItemKey CarrierArrived = new ItemKey("#carrier_arrived");
        public static readonly ItemKey TransportKind = new ItemKey("#transport_kind");
        public static readonly ItemKey TransportType = new ItemKey("#transport_type");
        public static readonly ItemKey DriverWait = new ItemKey("#driver_wait");
        public static readonly ItemKey Driver = new ItemKey("#driver");

        public static readonly ItemKey Railcar = new ItemKey("#railcar");
        public static readonly ItemKey Seal1 = new ItemKey("#seal1");
        public static readonly ItemKey Seal2 = new ItemKey("#seal2");
        public static readonly ItemKey Seal3 = new ItemKey("#seal3");
        public static readonly ItemKey WeighbridgeWeightNet = new ItemKey("#weighbridge_weight_net");
        public static readonly ItemKey WeighbridgeWeightGross = new ItemKey("#weighbridge_weight_gross");
        public static readonly ItemKey ContainerFreeUntilOnTerminal = new ItemKey("#container_free_until_on_terminal");
        public static readonly ItemKey ContainerFreeUntilOnTerminalCustomerAgreement = new ItemKey("#container_free_until_on_terminal_customer_agreement");
        public static readonly ItemKey Adr = new ItemKey("#adr");

        public static readonly ItemKey CustomsDocument = new ItemKey("#customs_document");
        public static readonly ItemKey CustomsDocumentNumber = new ItemKey("#customs_document_number");
        public static readonly ItemKey CustomsDocumentOffice = new ItemKey("#customs_document_office");
        public static readonly ItemKey CustomsDocumentDate = new ItemKey("#customs_document_date");

        public static readonly ItemKey ArrivalExpected = new ItemKey("#arrival_expected");
        public static readonly ItemKey ArrivalArrived = new ItemKey("#arrival_arrived");
        public static readonly ItemKey ArrivalLatest = new ItemKey("#arrival_latest");

        public static readonly ItemKey LoadingDock = new ItemKey("#loading_dock");
        public static readonly ItemKey EOrderPriority = new ItemKey("#eorder_priority");
        public static readonly ItemKey EOrderPriorityValue = new ItemKey("#eorder_priority_value");
        public static readonly ItemKey DispatchPriority = new ItemKey("#dispatch_priority");
        public static readonly ItemKey DispatchTo = new ItemKey("#dispatch_to");
        public static readonly ItemKey DispatchComment = new ItemKey("#dispatch_comment");
        public static readonly ItemKey Zone = new ItemKey("#zone");
        public static readonly ItemKey ProductOverview = new ItemKey("#product_overview");
        public static readonly ItemKey LotbatchOverview = new ItemKey("#lotbatch_overview");

        public static readonly ItemKey OperationalStatus = new ItemKey("#operational_status");
        public static readonly ItemKey OperationalOperant = new ItemKey("#operational_operant");
        
        public ItemKey(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw Error.Argument(string.Format("{0} can't be empty.", nameof(value)));
            }

            Value = value;
        }

        public string Value { get; }

        public static IEnumerable<ItemKey> List()
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
