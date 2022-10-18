using System.Net;
using System.Text;

namespace BeanSceneAppV1.Models
{
    public class CrudTemplate
    {
        public string ButtonType { get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }
        public int? AreaId { get; set; }
        public int? TableId { get; set; }
        public int? SittingId { get; set; }
        public int? TimeSlotId { get; set; }
        public int? ReservationId { get; set; }
        public int? TableAvailabilityId { get; set; }
        public int? MemberId { get; set; }
        public int? MemberShipTypeId { get; set; }
        public string ActionParameter
        {
            get
            {
                var param = new StringBuilder("/");

               
                if (AreaId != null && AreaId > 0)
                {
                    param.Append(String.Format("{0}", AreaId));
                }
                if (TableId != null && TableId > 0)
                {
                    param.Append(String.Format("{0}", TableId));
                }
                if (SittingId != null && SittingId > 0)
                {
                    param.Append(String.Format("{0}", SittingId));
                }
                if (TimeSlotId != null && TimeSlotId > 0)
                {
                    param.Append(String.Format("{0}", TimeSlotId));
                }
                if (ReservationId != null && ReservationId > 0)
                {
                    param.Append(String.Format("{0}", ReservationId));
                }
                if (TableAvailabilityId != null && TableAvailabilityId > 0)
                {
                    param.Append(String.Format("{0}", TableAvailabilityId));
                }
                if (MemberId != null && MemberId > 0)
                {
                    param.Append(String.Format("{0}", MemberId));
                }
                if (MemberShipTypeId != null && MemberShipTypeId > 0)
                {
                    param.Append(String.Format("{0}", MemberShipTypeId));
                }
                return param.ToString();
            }
        }
    }
}
