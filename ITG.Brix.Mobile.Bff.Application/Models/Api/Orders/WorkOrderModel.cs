using ITG.Brix.Mobile.Bff.Domain;
using System;

namespace ITG.Brix.Mobile.Bff.Application.Models.Api
{
    public class WorkOrderModel
    {
        public Guid Id { get; set; }
        public bool IsEditable { get; set; }
        public string UserCreated { get; set; }
        public string CreatedOn { get; set; }
        public OrderModel Order { get; set; }
        public OperationalModel Operational { get; set; }
        public string Version { get; set; }

        //TODO: refactor 
        public string Get(string request)
        {
            if (request == ItemKey.Source.Value)
            {
                return Order.Origin.Source;
            }
            if (request == ItemKey.CustomerName.Value)
            {
                return Order.Customer.Code;
            }
            if (request == ItemKey.TransportNumber.Value)
            {
                return Order.Number;
            }
            if (request == ItemKey.LoadingPlace.Value)
            {
                return Order.Transport.Loading.Place;
            }
            if (request == ItemKey.LoadingReference.Value)
            {
                return Order.Transport.Loading.Reference;
            }
            if (request == ItemKey.Site.Value)
            {
                return Order.Operation.Site;
            }
            if (request == ItemKey.OperationalDepartment.Value)
            {
                return Order.Operation.OperationalDepartment;
            }
            if (request == ItemKey.DockingZone.Value)
            {
                return Order.Operation.DockingZone;
            }
            if (request == ItemKey.LicensePlateTruck.Value)
            {
                return Order.Transport.Truck.LicensePlateTruck;
            }
            if (request == ItemKey.LicensePlateTrailer.Value)
            {
                return Order.Transport.Truck.LicensePlateTrailer;
            }
            if (request == ItemKey.ContainerNumber.Value)
            {
                return Order.Transport.Container.Number;
            }
            if (request == ItemKey.ContainerLocation.Value)
            {
                return Order.Transport.Container.Location;
            }
            if (request == ItemKey.ContainerStackLocation.Value)
            {
                return Order.Transport.Container.StackLocation;
            }
            if (request == ItemKey.SourceOrderId.Value)
            {
                return Order.Origin.EntryNumber;
            }
            if (request == ItemKey.OperationType.Value)
            {
                return Order.Operation.Type;
            }
            if (request == ItemKey.OperationGroup.Value)
            {
                return Order.Operation.Group;
            }
            if (request == ItemKey.Operation.Value)
            {
                return Order.Operation.Name;
            }
            if (request == ItemKey.UnitPlanning.Value)
            {
                return Order.Operation.UnitPlanning;
            }
            if (request == ItemKey.TypePlanning.Value)
            {
                return Order.Operation.TypePlanning;
            }
            if (request == ItemKey.Reference1.Value)
            {
                return Order.Customer.Reference1;
            }
            if (request == ItemKey.Reference2.Value)
            {
                return Order.Customer.Reference2;
            }
            if (request == ItemKey.Reference3.Value)
            {
                return Order.Customer.Reference3;
            }
            if (request == ItemKey.Reference4.Value)
            {
                return Order.Customer.Reference4;
            }
            if (request == ItemKey.Reference5.Value)
            {
                return Order.Customer.Reference5;
            }
            if (request == ItemKey.ArdReference1.Value)
            {
                return Order.Transport.Ard.Reference1;
            }
            if (request == ItemKey.ArdReference2.Value)
            {
                return Order.Transport.Ard.Reference2;
            }
            if (request == ItemKey.ArdReference3.Value)
            {
                return Order.Transport.Ard.Reference3;
            }
            if (request == ItemKey.ArdReference4.Value)
            {
                return Order.Transport.Ard.Reference4;
            }
            if (request == ItemKey.ArdReference5.Value)
            {
                return Order.Transport.Ard.Reference5;
            }
            if (request == ItemKey.ArdReference6.Value)
            {
                return Order.Transport.Ard.Reference6;
            }
            if (request == ItemKey.ArdReference7.Value)
            {
                return Order.Transport.Ard.Reference7;
            }
            if (request == ItemKey.ArdReference8.Value)
            {
                return Order.Transport.Ard.Reference8;
            }
            if (request == ItemKey.ArdReference9.Value)
            {
                return Order.Transport.Ard.Reference9;
            }
            if (request == ItemKey.ArdReference10.Value)
            {
                return Order.Transport.Ard.Reference10;
            }
            if (request == ItemKey.ProductionSite.Value)
            {
                return Order.Customer.ProductionSite;
            }
            if (request == ItemKey.DeliveryPlace.Value)
            {
                return Order.Transport.Delivery.Place;
            }
            if (request == ItemKey.BillOfLading.Value)
            {
                return Order.Transport.BillOfLading.Number;
            }
            if (request == ItemKey.BillOfLadingWeightNet.Value)
            {
                return Order.Transport.BillOfLading.WeightNet;
            }
            if (request == ItemKey.BillOfLadingWeightGross.Value)
            {
                return Order.Transport.BillOfLading.WeightGross;
            }
            if (request == ItemKey.CertificateOfOrigin.Value)
            {
                return Order.Customs.CertificateOfOrigin;
            }
            if (request == ItemKey.CarrierBooked.Value)
            {
                return Order.Transport.Carrier.Booked;
            }
            if (request == ItemKey.CarrierArrived.Value)
            {
                return Order.Transport.Carrier.Arrived;
            }
            if (request == ItemKey.TransportKind.Value)
            {
                return Order.Transport.Kind;
            }
            if (request == ItemKey.TransportType.Value)
            {
                return Order.Transport.Type;
            }
            if (request == ItemKey.DriverWait.Value)
            {
                return Order.Transport.Driver.Wait;
            }
            if (request == ItemKey.Driver.Value)
            {
                return Order.Transport.Driver.Name;
            }
            if (request == ItemKey.Railcar.Value)
            {
                return Order.Transport.Railcar.Number;
            }
            if (request == ItemKey.Seal1.Value)
            {
                return Order.Transport.Seal.Seal1;
            }
            if (request == ItemKey.Seal2.Value)
            {
                return Order.Transport.Seal.Seal2;
            }
            if (request == ItemKey.Seal3.Value)
            {
                return Order.Transport.Seal.Seal3;
            }
            if (request == ItemKey.WeighbridgeWeightNet.Value)
            {
                return Order.Transport.Weighbridge.Net;
            }
            if (request == ItemKey.WeighbridgeWeightGross.Value)
            {
                return Order.Transport.Weighbridge.Gross;
            }
            if (request == ItemKey.ContainerFreeUntilOnTerminal.Value)
            {
                return Order.Transport.Container.FreeUntilOnTerminal.ShippingLine;
            }
            if (request == ItemKey.ContainerFreeUntilOnTerminalCustomerAgreement.Value)
            {
                return Order.Transport.Container.FreeUntilOnTerminal.Customer;
            }
            if (request == ItemKey.Adr.Value)
            {
                return Order.Transport.Adr;
            }
            if (request == ItemKey.CustomsDocument.Value)
            {
                return Order.Customs.Document.Number;
            }
            if (request == ItemKey.CustomsDocument.Value)
            {
                return Order.Customs.Document.Name;
            }
            if (request == ItemKey.CustomsDocumentNumber.Value)
            {
                return Order.Customs.Document.Number;
            }
            if (request == ItemKey.CustomsDocumentOffice.Value)
            {
                return Order.Customs.Document.Office;
            }
            if (request == ItemKey.CustomsDocumentDate.Value)
            {
                return Order.Customs.Document.Date;
            }
            if (request == ItemKey.ArrivalExpected.Value)
            {
                return Order.Transport.Arrival.Expected;
            }
            if (request == ItemKey.ArrivalArrived.Value)
            {
                return Order.Transport.Arrival.Arrived;
            }
            if (request == ItemKey.ArrivalLatest.Value)
            {
                return Order.Transport.Arrival.Latest;
            }
            if (request == ItemKey.LoadingDock.Value)
            {
                return Order.Operation.LoadingDock;
            }
            if (request == ItemKey.EOrderPriority.Value)
            {
                return Order.Operation.Priority.Code;
            }
            if (request == ItemKey.EOrderPriorityValue.Value)
            {
                return Order.Operation.Priority.Value;
            }
            if (request == ItemKey.DispatchPriority.Value)
            {
                return Order.Operation.Dispatch.Priority;
            }
            if (request == ItemKey.DispatchTo.Value)
            {
                return Order.Operation.Dispatch.To;
            }
            if (request == ItemKey.DispatchComment.Value)
            {
                return Order.Operation.Dispatch.Comment;
            }
            if (request == ItemKey.Zone.Value)
            {
                return Order.Operation.Zone;
            }
            if (request == ItemKey.ProductOverview.Value)
            {
                return Order.Operation.ProductOverview;
            }
            if (request == ItemKey.LotbatchOverview.Value)
            {
                return Order.Operation.LotbatchOverview;
            }

            return string.Empty;
        }
    }
}
