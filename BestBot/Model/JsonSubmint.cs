using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBot.Model
{
    public class JsonSubmint
    {
        public string access_key { get; set; }
        public string amount { get; set; }
        public string bill_to_address_city { get; set; }
        public string bill_to_address_country { get; set; }
        public string bill_to_address_line1 { get; set; }
        public string bill_to_email { get; set; }
        public string bill_to_forename { get; set; }
        public string bill_to_surname { get; set; }
        public string card_expiry_date { get; set; }
        public string card_type { get; set; }
        public string currency { get; set; }
        public string locale { get; set; }
        public string payment_method { get; set; }
        public string profile_id { get; set; }
        public string reference_number { get; set; }
        public string signed_date_time { get; set; }
        public string transaction_uuid { get; set; }
        public string transaction_type { get; set; }
        public string unsigned_field_names { get; set; }
        public string override_custom_receipt_page { get; set; }
        public string bill_to_phone { get; set; }
        public string bill_to_address_state { get; set; }
        public string bill_to_address_postal_code { get; set; }
        public string device_fingerprint_id { get; set; }
        public string customer_ip_address { get; set; }
        public string merchant_defined_data1 { get; set; }
        public string merchant_defined_data2 { get; set; }
        public string merchant_defined_data4 { get; set; }
        public string merchant_defined_data6 { get; set; }
        public string merchant_defined_data7 { get; set; }
        public string ship_to_address_city { get; set; }
        public string ship_to_address_country { get; set; }
        public string ship_to_address_line1 { get; set; }
        public string ship_to_address_postal_code { get; set; }
        public string ship_to_address_state { get; set; }
        public string ship_to_forename { get; set; }
        public string ship_to_phone { get; set; }
        public string ship_to_surname { get; set; }
        public string item_0_quantity { get; set; }
        public string item_0_unit_price { get; set; }
        public string item_0_code { get; set; }
        public string item_0_name { get; set; }
        public string item_0_sku { get; set; }
        public string item_0_tax_amount { get; set; }
        public string item_1_quantity { get; set; }
        public string item_1_unit_price { get; set; }
        public string item_1_code { get; set; }
        public string item_1_name { get; set; }
        public string item_1_sku { get; set; }
        public string item_1_tax_amount { get; set; }
        public string tax_amount { get; set; }
        public string line_item_count { get; set; }
        public string signed_field_names { get; set; }
        public string signature { get; set; }
    }
}
