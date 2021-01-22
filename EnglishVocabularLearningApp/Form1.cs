using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Media;
using System.Globalization;


//ÖZELLİKLER MENÜSÜNDE YAPTIKLARIM
//buton1 2 ve 3 ün TabStop'larını false yaptım. Tab ile gezmemek için.
namespace EnglishVocabularLearningApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        bool seslendirme = true;
        bool arkaplanmuzik = true;

        public Form1(bool sesayari,bool arkaplanmuzik)
        {
            seslendirme = sesayari;
            this.arkaplanmuzik = arkaplanmuzik;
            InitializeComponent();
        }
        bool deneme = true;
        public Form1(bool sesayari, bool arkaplanmuzik,bool deneme)
        {
            seslendirme = sesayari;
            this.arkaplanmuzik = arkaplanmuzik;
            this.deneme = deneme;
            InitializeComponent();
        }


        SpeechSynthesizer okuyucu = new SpeechSynthesizer();
        

        string[] english = new string[10];     //Burda dizileri 15 elemanlı yaptığımız için bütün kategorilere 15 kelime girmeliyiz.
        string[] turkish = new string[10];     //Yani buraya kaç yazarsak kategorilerin hepsine o kadar kelime girmeliyiz.



        Random rnd = new Random();

        int puan;
        int yanlissayisi;
        


        public string kategori;
        #region gundelik
        private void Gundelik()
        {

            Array.Resize(ref english, 403);
            Array.Resize(ref turkish, 403);

            english[0] = "family"; turkish[0] = "aile";
            english[1] = "they"; turkish[1] = "onlar";
            english[2] = "with"; turkish[2] = "ile";
            english[3] = "make"; turkish[3] = "yapmak";
            english[4] = "if"; turkish[4] = "eğer";
            english[5] = "man"; turkish[5] = "erkek";
            english[6] = "women"; turkish[6] = "kadın";
            english[7] = "out"; turkish[7] = "dışarısı";
            english[8] = "other"; turkish[8] = "diğer";
            english[9] = "about"; turkish[9] = "hakkında";
            english[10] = "only"; turkish[10] = "sadece";
            english[11] = "new"; turkish[11] = "yeni";
            english[12] = "some"; turkish[12] = "biraz";
            english[13] = "come"; turkish[13] = "gelmek";
            english[14] = "know"; turkish[14] = "bilmek";
            english[15] = "see"; turkish[15] = "görmek";
            english[16] = "year"; turkish[16] = "yıl";
            english[17] = "use"; turkish[17] = "kullanmak";
            english[18] = "first"; turkish[18] = "birinci";
            english[19] = "work"; turkish[19] = "iş";
            english[20] = "day"; turkish[20] = "gün";
            english[21] = "find"; turkish[21] = "bulmak";
            english[22] = "look"; turkish[22] = "bakmak";
            english[23] = "before"; turkish[23] = "önce";
            english[24] = "after"; turkish[24] = "sonra";
            english[25] = "back"; turkish[25] = "geri";
            english[26] = "long"; turkish[26] = "uzun";
            english[27] = "because"; turkish[27] = "çünkü";
            english[28] = "feel"; turkish[28] = "hissetmek";
            english[29] = "high"; turkish[29] = "yüksek";
            english[30] = "place"; turkish[30] = "yer";
            english[31] = "little"; turkish[31] = "küçük";
            english[32] = "world"; turkish[32] = "dünya";
            english[33] = "old"; turkish[33] = "eski";
            english[34] = "life"; turkish[34] = "hayat";
            english[35] = "write"; turkish[35] = "yazmak";
            english[36] = "read"; turkish[36] = "okumak";
            english[37] = "tell"; turkish[37] = "söylemek";
            english[38] = "show"; turkish[38] = "göstermek";
            english[39] = "shake"; turkish[39] = "sallamak";
            english[40] = "climb"; turkish[40] = "tırmanmak";
            english[41] = "catch"; turkish[41] = "yakalamak";
            english[42] = "laugh"; turkish[42] = "gülmek";
            english[43] = "hear"; turkish[43] = "duymak";
            english[44] = "fold"; turkish[44] = "katlamak";
            english[45] = "smile"; turkish[45] = "gülümsemek";
            english[46] = "change"; turkish[46] = "değiştirmek";
            english[47] = "listen"; turkish[47] = "dinlemek";
            english[48] = "follow"; turkish[48] = "takip etmek";
            english[49] = "ask"; turkish[49] = "sormak";
            english[50] = "cut"; turkish[50] = "kesmek";
            english[51] = "put"; turkish[51] = "koymak";
            english[52] = "accident"; turkish[52] = "kaza";
            english[53] = "advice"; turkish[53] = "tavsiye";
            english[54] = "afternoon"; turkish[54] = "öğleden sonra";
            english[55] = "age"; turkish[55] = "yaş";
            english[56] = "allow"; turkish[56] = "izin vermek";
            english[57] = "alone"; turkish[57] = "yalnız";
            english[58] = "always"; turkish[58] = "her zaman";
            english[59] = "angry"; turkish[59] = "kızgın";
            english[60] = "animal"; turkish[60] = "hayvan";
            english[61] = "answer"; turkish[61] = "yanıt";
            english[62] = "author"; turkish[62] = "yazar";
            english[63] = "autumn"; turkish[63] = "sonbahar";
            english[64] = "average"; turkish[64] = "ortalama";
            english[65] = "between"; turkish[65] = "arasında";
            english[66] = "birthday"; turkish[66] = "doğumgünü";
            english[67] = "breakfast"; turkish[67] = "kahvaltı";
            english[68] = "bridge"; turkish[68] = "köprü";
            english[69] = "bright"; turkish[69] = "parlak";
            english[70] = "brother"; turkish[70] = "erkek kardeş";
            english[71] = "build"; turkish[71] = "inşa etmek";
            english[72] = "budget"; turkish[72] = "bütçe";
            english[73] = "bus"; turkish[73] = "otobüs";
            english[74] = "car"; turkish[74] = "araba";
            english[75] = "buy"; turkish[75] = "satın almak";
            english[76] = "calculate"; turkish[76] = "hesaplamak";
            english[77] = "calendar"; turkish[77] = "takvim";
            english[78] = "capacity"; turkish[78] = "kapasite";
            english[79] = "cash"; turkish[79] = "nakit";
            english[80] = "caution"; turkish[80] = "uyarı";
            english[81] = "celebration"; turkish[81] = "kutlama";
            english[82] = "center"; turkish[82] = "merkez";
            english[83] = "cheap"; turkish[83] = "ucuz";
            english[84] = "child"; turkish[84] = "çocuk";
            english[85] = "choose"; turkish[85] = "seçmek";
            english[86] = "fly"; turkish[86] = "uçmak";
            english[87] = "drink"; turkish[87] = "içmek";
            english[88] = "send"; turkish[88] = "göndermek";
            english[89] = "pride"; turkish[89] = "gurur";
            english[90] = "abhor"; turkish[90] = "nefret etmek";
            english[91] = "legacy"; turkish[91] = "miras";
            english[92] = "today"; turkish[92] = "bugün";
            english[93] = "yesterday"; turkish[93] = "dün";
            english[94] = "tomorrow"; turkish[94] = "yarın";
            english[95] = "north"; turkish[95] = "kuzey";
            english[96] = "south"; turkish[96] = "güney";
            english[97] = "east"; turkish[97] = "doğu";
            english[98] = "west"; turkish[98] = "batı";
            english[99] = "emergency"; turkish[99] = "acil durum";
            english[100] = "airport"; turkish[100] = "havalimanı";
            english[101] = "soft"; turkish[101] = "yumuşak";
            english[102] = "dry"; turkish[102] = "kuru";
            english[103] = "wet"; turkish[103] = "ıslak";
            english[104] = "lazy"; turkish[104] = "tembel";
            english[105] = "diligent"; turkish[105] = "çalışkan";
            english[106] = "thick"; turkish[106] = "kalın";
            english[107] = "thin"; turkish[107] = "ince";
            english[108] = "deserve"; turkish[108] = "layık olmak";
            english[109] = "under"; turkish[109] = "altında";
            english[110] = "split"; turkish[110] = "bölmek";
            english[111] = "spread"; turkish[111] = "yaymak";
            english[112] = "beat"; turkish[112] = "yenmek";
            english[113] = "imitation"; turkish[113] = "taklit";
            english[114] = "competition"; turkish[114] = "yarışma";
            english[115] = "precaution"; turkish[115] = "tedbir";
            english[116] = "demand"; turkish[116] = "talep";
            english[117] = "clue"; turkish[117] = "ipucu";
            english[118] = "blame"; turkish[118] = "suçlama";
            english[119] = "insist"; turkish[119] = "ısrar etmek";
            english[120] = "derive"; turkish[120] = "türetmek";
            english[121] = "decision"; turkish[121] = "karar";
            english[122] = "aktual"; turkish[122] = "gerçek";
            english[123] = "silent"; turkish[123] = "sessiz";
            english[124] = "order"; turkish[124] = "sipariş";
            english[125] = "gorgeous"; turkish[125] = "muhteşem";
            english[126] = "apply"; turkish[126] = "uygulamak";
            english[127] = "threat"; turkish[127] = "tehdit";
            english[128] = "stroll"; turkish[128] = "gezinti";
            english[129] = "exactly"; turkish[129] = "kesinlikle";
            english[130] = "priceless"; turkish[130] = "pahabiçilemez";
            english[131] = "rise"; turkish[131] = "yükselmek";
            english[132] = "patient"; turkish[132] = "sabırlı";
            english[133] = "explain"; turkish[133] = "açıklamak";
            english[134] = "survive"; turkish[134] = "hayatta kalmak";
            english[135] = "reject"; turkish[135] = "reddetmek";
            english[136] = "equivalent"; turkish[136] = "eşdeğer";
            english[137] = "touch"; turkish[137] = "dokunmak";
            english[138] = "appreciate"; turkish[138] = "takdir etmek";
            english[139] = "alert"; turkish[139] = "alarm";
            english[140] = "accomplish"; turkish[140] = "başarmak";
            english[141] = "adapt"; turkish[141] = "uyum sağlamak";
            english[142] = "advanced"; turkish[142] = "gelişmiş";
            english[143] = "ambition"; turkish[143] = "hırs";
            english[144] = "perseverance"; turkish[144] = "azim";
            english[145] = "destiny"; turkish[145] = "kader";
            english[146] = "respond"; turkish[146] = "yanıtlamak";
            english[147] = "application"; turkish[147] = "uygulama";
            english[148] = "include"; turkish[148] = "dahil etmek";
            english[149] = "contain"; turkish[149] = "içermek";
            english[150] = "Monday"; turkish[150] = "pazartesi";
            english[151] = "Tuesday"; turkish[151] = "salı";
            english[152] = "Wednesday"; turkish[152] = "çarşamba";
            english[153] = "Thursday"; turkish[153] = "perşembe";
            english[154] = "Friday"; turkish[154] = "cuma";
            english[155] = "Saturday"; turkish[155] = "cumartesi";
            english[156] = "Sunday"; turkish[156] = "pazar";
            english[157] = "January"; turkish[157] = "ocak";
            english[158] = "February"; turkish[158] = "şubat";
            english[159] = "March"; turkish[159] = "mart";
            english[160] = "April"; turkish[160] = "nisan";
            english[161] = "May"; turkish[161] = "mayıs";
            english[162] = "June"; turkish[162] = "haziran";
            english[163] = "July"; turkish[163] = "temmuz";
            english[164] = "August"; turkish[164] = "ağustos";
            english[165] = "September"; turkish[165] = "eylül";
            english[166] = "October"; turkish[166] = "ekim";
            english[167] = "November"; turkish[167] = "kasım";
            english[168] = "December"; turkish[168] = "aralık";
            english[169] = "discussion"; turkish[169] = "tartışma";
            english[170] = "applause"; turkish[170] = "alkış";
            english[171] = "represent"; turkish[171] = "temsil etmek";
            english[172] = "throw"; turkish[172] = "fırlatmak";
            english[173] = "actually"; turkish[173] = "aslında";
            english[174] = "honest"; turkish[174] = "dürüst";
            english[175] = "compliment"; turkish[175] = "iltifat";
            english[176] = "achieve"; turkish[176] = "başarmak";
            english[177] = "recommend"; turkish[177] = "tavsiye etmek";
            english[178] = "mixed"; turkish[178] = "karışık";
            english[179] = "invisible"; turkish[179] = "görünmez";
            english[180] = "preparing"; turkish[180] = "hazırlamak";
            english[181] = "account"; turkish[181] = "hesap";
            english[182] = "embarrassed"; turkish[182] = "mahçup";
            english[183] = "bottle"; turkish[183] = "şişe";
            english[184] = "contentment"; turkish[184] = "memnuniyet";
            english[185] = "gossip"; turkish[185] = "dedikodu";
            english[186] = "dungeon"; turkish[186] = "zindan";
            english[187] = "accuse"; turkish[187] = "suçlamak";
            english[188] = "certainly"; turkish[188] = "kesinlikle";
            english[189] = "assessment"; turkish[189] = "değerlendirme";
            english[190] = "process"; turkish[190] = "süreç";
            english[191] = "election"; turkish[191] = "seçim";
            english[192] = "future"; turkish[192] = "gelecek";
            english[193] = "feature"; turkish[193] = "özellik";
            english[194] = "supervisor"; turkish[194] = "gözetmen";
            english[195] = "preference"; turkish[195] = "tercih";
            english[196] = "align"; turkish[196] = "hizalamak";
            english[197] = "personalise"; turkish[197] = "kişiselleştirmek";
            english[198] = "graphic"; turkish[198] = "grafik";
            english[199] = "laboratory"; turkish[199] = "laboratuvar";
            english[200] = "continue"; turkish[200] = "devam etmek";
            english[201] = "wild"; turkish[201] = "vahşi";
            english[202] = "slideshow"; turkish[202] = "slayt gösterisi";
            english[203] = "new"; turkish[203] = "yeni";
            english[204] = "permission"; turkish[204] = "izin";
            english[205] = "status"; turkish[205] = "durum";
            english[206] = "vibrate"; turkish[206] = "titremek";
            english[207] = "configuration"; turkish[207] = "yapılandırma";
            english[208] = "access"; turkish[208] = "erişim";
            english[209] = "ignore"; turkish[209] = "aldırmamak";
            english[210] = "restricted"; turkish[210] = "kısıtlı";
            english[211] = "forbidden"; turkish[211] = "yasak";
            english[212] = "limited"; turkish[212] = "sınırlı";
            english[213] = "midnight"; turkish[213] = "gece yarısı";
            english[214] = "hide"; turkish[214] = "gizlemek";
            english[215] = "smell"; turkish[215] = "koku";
            english[216] = "valuable"; turkish[216] = "değerli";
            english[217] = "cause"; turkish[217] = "sebep olmak";
            english[218] = "publish"; turkish[218] = "yayınlamak";
            english[219] = "view"; turkish[219] = "görünüm";
            english[220] = "expand"; turkish[220] = "genişletmek";
            english[221] = "collapse"; turkish[221] = "daraltmak";
            english[222] = "activation"; turkish[222] = "etkinleştirme";
            english[223] = "top"; turkish[223] = "üst";
            english[224] = "bottom"; turkish[224] = "alt";
            english[225] = "tittle"; turkish[225] = "başlık";
            english[226] = "compare"; turkish[226] = "karşılaştırmak";
            english[227] = "variable"; turkish[227] = "değişken";
            english[228] = "organise"; turkish[228] = "düzenlemek";
            english[229] = "clipboard"; turkish[229] = "pano";
            english[230] = "customize"; turkish[230] = "özelleştirmek";
            english[231] = "general"; turkish[231] = "genel";
            english[232] = "attribute"; turkish[232] = "özellik";
            english[233] = "recycle"; turkish[233] = "geri dönüşüm";
            english[234] = "permanently"; turkish[234] = "kalıcı olarak";
            english[235] = "horror"; turkish[235] = "korku";
            english[236] = "gain"; turkish[236] = "kazanç";
            english[237] = "accurate"; turkish[237] = "doğru";
            english[238] = "opponent"; turkish[238] = "rakip";
            english[239] = "science"; turkish[239] = "bilim";
            english[240] = "middle"; turkish[240] = "orta";
            english[241] = "appropriate"; turkish[241] = "uygun";
            english[242] = "interaction"; turkish[242] = "etkileşim";
            english[243] = "attempt"; turkish[243] = "girişim";
            english[244] = "valentine"; turkish[244] = "sevgili";
            english[245] = "impressive"; turkish[245] = "etkileyici";
            english[246] = "liquid"; turkish[246] = "sıvı";
            english[247] = "fluid"; turkish[247] = "akışkan";
            english[248] = "dexterity"; turkish[248] = "beceri";
            english[249] = "installation"; turkish[249] = "kurulum";
            english[250] = "receive"; turkish[250] = "teslim almak";
            english[251] = "explore"; turkish[251] = "keşfetmek";
            english[252] = "contribute"; turkish[252] = "katkıda bulunmak";
            english[253] = "management"; turkish[253] = "yönetim";
            english[254] = "reason"; turkish[254] = "neden";
            english[255] = "goal"; turkish[255] = "hedef";
            english[256] = "habit"; turkish[256] = "alışkanlık";
            english[257] = "fix"; turkish[257] = "düzeltmek";
            english[258] = "tax"; turkish[258] = "vergi";
            english[259] = "unbelievable"; turkish[259] = "inanılmaz";
            english[260] = "guest"; turkish[260] = "konuk";
            english[261] = "fiction"; turkish[261] = "kurgu";
            english[262] = "comfortable"; turkish[262] = "rahat";
            english[263] = "condition"; turkish[263] = "şart";
            english[264] = "vacation"; turkish[264] = "tatil";
            english[265] = "town"; turkish[265] = "kasaba";
            english[266] = "check"; turkish[266] = "kontrol etmek";
            english[267] = "chat"; turkish[267] = "sohbet";
            english[268] = "cheerful"; turkish[268] = "neşeli";
            english[269] = "clipbcoard"; turkish[269] = "pano";
            english[270] = "cinema"; turkish[270] = "sinema";
            english[271] = "school"; turkish[271] = "okul";
            english[272] = "museum"; turkish[272] = "müze";
            english[273] = "bank"; turkish[273] = "banka";
            english[274] = "hospital"; turkish[274] = "hastane";
            english[275] = "post office"; turkish[275] = "postane";
            english[276] = "supermarket"; turkish[276] = "süpermarket";
            english[277] = "hotel"; turkish[277] = "otel";
            english[278] = "library"; turkish[278] = "kütüphane";
            english[279] = "barbers shop"; turkish[279] = "berber dükkanı";
            english[280] = "restaurant"; turkish[280] = "lokanta";
            english[281] = "bakery"; turkish[281] = "fırın";
            english[282] = "gas station"; turkish[282] = "benzin istasyonu";
            english[283] = "pharmacy"; turkish[283] = "eczane";
            english[284] = "bus station"; turkish[284] = "otobüs durağı";
            english[285] = "airport"; turkish[285] = "hava alanı";
            english[286] = "clothing store"; turkish[286] = "giyim mağazası";
            english[287] = "circle"; turkish[287] = "çember";
            english[288] = "circus"; turkish[288] = "sirk";
            english[289] = "civil"; turkish[289] = "sivil";
            english[290] = "clap"; turkish[290] = "alkış";
            english[291] = "classic"; turkish[291] = "klasik";
            english[292] = "clean"; turkish[292] = "temiz";
            english[293] = "clever"; turkish[293] = "zeki";
            english[294] = "cloud"; turkish[294] = "bulut";
            english[295] = "clown"; turkish[295] = "palyaço";
            english[296] = "cold"; turkish[296] = "soğuk";
            english[297] = "hot"; turkish[297] = "sıcak";
            english[298] = "collect"; turkish[298] = "toplamak";
            english[299] = "colour"; turkish[299] = "renk";
            english[300] = "comfort"; turkish[300] = "konfor";
            english[301] = "concert"; turkish[301] = "konser";
            english[302] = "comfortable"; turkish[302] = "rahat";
            english[303] = "trust"; turkish[303] = "güven";
            english[304] = "cop"; turkish[304] = "polis";
            english[305] = "corner"; turkish[305] = "köşe";
            english[306] = "corridor"; turkish[306] = "koridor";
            english[307] = "cosmetic"; turkish[307] = "kozmetik";
            english[308] = "cost"; turkish[308] = "maliyet";
            english[309] = "cotton"; turkish[309] = "pamuk";
            english[310] = "count"; turkish[310] = "saymak";
            english[311] = "country"; turkish[311] = "ülke";
            english[312] = "cousin"; turkish[312] = "kuzen";
            english[313] = "crazy"; turkish[313] = "çılgın";
            english[314] = "cry"; turkish[314] = "ağlamak";
            english[315] = "culture "; turkish[315] = "kültür";
            english[316] = "cut"; turkish[316] = "kesmek";
            english[317] = "cycle"; turkish[317] = "bisiklet";
            english[318] = "dad"; turkish[318] = "baba";
            english[319] = "mom"; turkish[319] = "anne";
            english[320] = "sister"; turkish[320] = "kız kardeş";
            english[321] = "danger"; turkish[321] = "tehlike";
            english[322] = "dance"; turkish[322] = "dans";
            english[323] = "day"; turkish[323] = "gün";
            english[324] = "week"; turkish[324] = "hafta";
            english[325] = "month"; turkish[325] = "ay";
            english[326] = "son"; turkish[326] = "erkek evlat";
            english[327] = "daughter"; turkish[327] = "kız evlat";
            english[328] = "death"; turkish[328] = "ölüm";
            english[329] = "debt"; turkish[329] = "borç";
            english[330] = "delicious"; turkish[330] = "lezzetli";
            english[331] = "dentist"; turkish[331] = "dişçi";
            english[332] = "lawyer"; turkish[332] = "avukat";
            english[333] = "soldier"; turkish[333] = "asker";
            english[334] = "farmer"; turkish[334] = "çiftçi";
            english[335] = "chemist"; turkish[335] = "eczacı";
            english[336] = "doctor"; turkish[336] = "doktor";
            english[337] = "waiter"; turkish[337] = "garson";
            english[338] = "judge"; turkish[338] = "hakim";
            english[339] = "nurse"; turkish[339] = "hemşire";
            english[340] = "stewardess"; turkish[340] = "hostes";
            english[341] = "butcher"; turkish[341] = "kasap";
            english[342] = "jeweller"; turkish[342] = "kuyumcu";
            english[343] = "greengrocer"; turkish[343] = "manav";
            english[344] = "architect"; turkish[344] = "mimar";
            english[345] = "engineer"; turkish[345] = "mühendis";
            english[346] = "teacher"; turkish[346] = "öğretmen";
            english[347] = "tailor"; turkish[347] = "terzi";
            english[348] = "dirty"; turkish[348] = "kirli";
            english[349] = "discover"; turkish[349] = "keşfetmek";
            english[350] = "divide"; turkish[350] = "bölmek";
            english[351] = "donate"; turkish[351] = "bağış yapmak";
            english[352] = "doubt"; turkish[352] = "şüphe";
            english[353] = "draw"; turkish[353] = "çizmek";
            english[354] = "drink"; turkish[354] = "içmek";
            english[355] = "early"; turkish[355] = "erken";
            english[356] = "elegant"; turkish[356] = "zarif";
            english[357] = "energy"; turkish[357] = "enerji";
            english[358] = "enjoy"; turkish[358] = "eğlenmek";
            english[359] = "escape"; turkish[359] = "kaçmak";
            english[360] = "event"; turkish[360] = "olay";
            english[361] = "interpreter"; turkish[361] = "tercüman";
            english[362] = "postman"; turkish[362] = "postacı";
            english[363] = "reporter"; turkish[363] = "muhabir";
            english[364] = "miner"; turkish[364] = "madenci";
            english[365] = "except"; turkish[365] = "dışında";
            english[366] = "exception"; turkish[366] = "istisna";
            english[367] = "exercise"; turkish[367] = "egzersiz";
            english[368] = "experience"; turkish[368] = "tecrübe";
            english[369] = "fast"; turkish[369] = "hızlı";
            english[370] = "fear"; turkish[370] = "korku";
            english[371] = "fill"; turkish[371] = "doldurmak";
            english[372] = "finger"; turkish[372] = "parmak";
            english[373] = "flag"; turkish[373] = "bayrak";
            english[374] = "flower"; turkish[374] = "çiçek";
            english[375] = "tree "; turkish[375] = "ağaç";
            english[376] = "foam"; turkish[376] = "köpük";
            english[377] = "foot"; turkish[377] = "ayak";
            english[378] = "foreign"; turkish[378] = "yabancı";
            english[379] = "forest"; turkish[379] = "orman";
            english[380] = "fresh"; turkish[380] = "taze";
            english[381] = "friend"; turkish[381] = "arkadaş";
            english[382] = "game"; turkish[382] = "oyun";
            english[383] = "garden"; turkish[383] = "bahçe";
            english[384] = "grow"; turkish[384] = "büyümek";
            english[385] = "happy"; turkish[385] = "mutlu";
            english[386] = "heavy"; turkish[386] = "ağır";
            english[387] = "help"; turkish[387] = "yardım";
            english[388] = "hobby"; turkish[388] = "hobi";
            english[389] = "holiday"; turkish[389] = "tatil";
            english[390] = "joke"; turkish[390] = "şaka";
            english[391] = "kid"; turkish[391] = "çocuk";
            english[392] = "kiss"; turkish[392] = "öpmek";
            english[393] = "luck"; turkish[393] = "şans";
            english[394] = "telephone"; turkish[394] = "telefon";
            english[395] = "photo"; turkish[395] = "fotoğraf";
            english[396] = "picnic"; turkish[396] = "piknik";
            english[397] = "price"; turkish[397] = "fiyat";
            english[398] = "promise"; turkish[398] = "söz vermek";
            english[399] = "ticket"; turkish[399] = "bilet";
            english[400] = "toilet"; turkish[400] = "tuvalet";
            english[401] = "wash"; turkish[401] = "yıkamak";
            english[402] = "young"; turkish[402] = "genç";


            //english[403] = "greengrocer"; turkish[403] = "manav";
            //english[404] = "architect"; turkish[404] = "mimar";
            //english[405] = "engineer"; turkish[405] = "mühendis";
            //english[406] = "teacher"; turkish[406] = "öğretmen";
            //english[407] = "tailor"; turkish[407] = "terzi";
            //english[408] = "dirty"; turkish[408] = "kirli";
            //english[409] = "discover"; turkish[409] = "keşfetmek";
            //english[410] = "divide"; turkish[410] = "bölmek";
            //english[411] = "donate"; turkish[411] = "bağış yapmak";
            //english[412] = "doubt"; turkish[412] = "şüphe";
            //english[413] = "draw"; turkish[413] = "çizmek";
            //english[414] = "drink"; turkish[414] = "içmek";
            //english[415] = "early"; turkish[415] = "erken";
            //english[416] = "elegant"; turkish[416] = "zarif";
            //english[417] = "energy"; turkish[417] = "enerji";
            //english[418] = "enjoy"; turkish[418] = "eğlenmek";
            //english[419] = "escape"; turkish[419] = "kaçmak";
            //english[420] = "event"; turkish[420] = "olay";
            //english[421] = "interpreter"; turkish[421] = "tercüman";
            //english[422] = "postman"; turkish[422] = "postacı";
            //english[423] = "reporter"; turkish[423] = "muhabir";
            //english[424] = "miner"; turkish[424] = "madenci";



        }
        #endregion
        #region akademik
        private void Akademik()
        {
            Array.Resize(ref english, 179);
            Array.Resize(ref turkish, 179);

            english[0] = "revenue"; turkish[0] = "gelir";
            english[1] = "function"; turkish[1] = "işlev";
            english[2] = "generation"; turkish[2] = "nesil";
            english[3] = "obtain"; turkish[3] = "elde etmek";
            english[4] = "area"; turkish[4] = "alan";
            english[5] = "ambiguous"; turkish[5] = "belirsiz";
            english[6] = "environment"; turkish[6] = "çevre";
            english[7] = "migrate"; turkish[7] = "göç etmek";
            english[8] = "valid"; turkish[8] = "geçerli";
            english[9] = "passive"; turkish[9] = "pasif";
            english[10] = "establish"; turkish[10] = "kurmak";
            english[11] = "file"; turkish[11] = "dosya";
            english[12] = "style"; turkish[12] = "tarz";
            english[13] = "technology"; turkish[13] = "teknoloji";
            english[14] = "confirm"; turkish[14] = "onaylamak";
            english[15] = "discrete"; turkish[15] = "ayrık";
            english[16] = "register"; turkish[16] = "kayıt olmak";
            english[17] = "error"; turkish[17] = "hata";
            english[18] = "vehicle"; turkish[18] = "araç";
            english[19] = "prohibit"; turkish[19] = "yasaklamak";
            english[20] = "define"; turkish[20] = "tanımlamak";
            english[21] = "brief"; turkish[21] = "kısa";
            english[22] = "convert"; turkish[22] = "dönüştürmek";
            english[23] = "abandon"; turkish[23] = "terketmek";
            english[24] = "invest"; turkish[24] = "yatırım yapmak";
            english[25] = "properties"; turkish[25] = "özellikler";
            english[26] = "delete"; turkish[26] = "silmek";
            english[27] = "share"; turkish[27] = "paylaşmak";
            english[28] = "compile"; turkish[28] = "derlemek";
            english[29] = "network"; turkish[29] = "ağ";
            english[30] = "generate"; turkish[30] = "üretmek";
            english[31] = "reverse"; turkish[31] = "ters";
            english[32] = "licence"; turkish[32] = "lisans";
            english[33] = "notion"; turkish[33] = "kavram";
            english[34] = "consult"; turkish[34] = "danışmak";
            english[35] = "medium"; turkish[35] = "orta";
            english[36] = "primary"; turkish[36] = "birincil";
            english[37] = "detect"; turkish[37] = "belirlemek";
            english[38] = "transmit"; turkish[38] = "iletmek";
            english[39] = "secure"; turkish[39] = "güvenli";
            english[40] = "team"; turkish[40] = "takım";
            english[41] = "classic"; turkish[41] = "klasik";
            english[42] = "chart"; turkish[42] = "grafik";
            english[43] = "expand"; turkish[43] = "genişletmek";
            english[44] = "derive"; turkish[44] = "türetmek";
            english[45] = "plus"; turkish[45] = "artı";
            english[46] = "project"; turkish[46] = "proje";
            english[47] = "input"; turkish[47] = "girdi";
            english[48] = "respond"; turkish[48] = "yanıtlamak";
            english[49] = "text"; turkish[49] = "metin";
            english[50] = "impact"; turkish[50] = "darbe";
            english[51] = "principle"; turkish[51] = "prensip";
            english[52] = "previous"; turkish[52] = "önceki";
            english[53] = "reject"; turkish[53] = "reddetmek";
            english[54] = "construct"; turkish[54] = "inşa etmek";
            english[55] = "domain"; turkish[55] = "alan";
            english[56] = "sufficient"; turkish[56] = "yeterli";
            english[57] = "route"; turkish[57] = "rota";
            english[58] = "device"; turkish[58] = "cihaz";
            english[59] = "channel"; turkish[59] = "kanal";
            english[60] = "priority"; turkish[60] = "öncelik";
            english[61] = "compute"; turkish[61] = "hesaplamak";
            english[62] = "potential"; turkish[62] = "potansiyel";
            english[63] = "individual"; turkish[63] = "bireysel";
            english[64] = "distribute"; turkish[64] = "dağıtmak";
            english[65] = "virtual"; turkish[65] = "sanal";
            english[66] = "research"; turkish[66] = "araştırmak";
            english[67] = "contemporary"; turkish[67] = "çağdaş";
            english[68] = "inspect"; turkish[68] = "denetlemek";
            english[69] = "concept"; turkish[69] = "kavram";
            english[70] = "media"; turkish[70] = "medya";
            english[71] = "layer"; turkish[71] = "katman";
            english[72] = "legal"; turkish[72] = "yasal";
            english[73] = "community"; turkish[73] = "topluluk";
            english[74] = "label"; turkish[74] = "etiket";
            english[75] = "feature"; turkish[75] = "özellik";
            english[76] = "item"; turkish[76] = "madde";
            english[77] = "structure"; turkish[77] = "yapı";
            english[78] = "sphere"; turkish[78] = "küre";
            english[79] = "percent"; turkish[79] = "yüzde";
            english[80] = "select"; turkish[80] = "seçmek";
            english[81] = "proportion"; turkish[81] = "oran";
            english[82] = "resource"; turkish[82] = "kaynak";
            english[83] = "survey"; turkish[83] = "anket";
            english[84] = "volume"; turkish[84] = "hacim";
            english[85] = "tradition"; turkish[85] = "gelenek";
            english[86] = "neutral"; turkish[86] = "tarafsız";
            english[87] = "intense"; turkish[87] = "yoğun";
            english[88] = "couple"; turkish[88] = "çift";
            english[89] = "logic"; turkish[89] = "mantık";
            english[90] = "category"; turkish[90] = "kategori";
            english[91] = "affect"; turkish[91] = "etkilemek";
            english[92] = "contact"; turkish[92] = "temas";
            english[93] = "inhibit"; turkish[93] = "engellemek";
            english[94] = "theme"; turkish[94] = "tema";
            english[95] = "external"; turkish[95] = "harici";
            english[96] = "constant"; turkish[96] = "sabit";
            english[97] = "draft"; turkish[97] = "taslak";
            english[98] = "equivalent"; turkish[98] = "eşdeğer";
            english[99] = "visible"; turkish[99] = "görünür";
            english[100] = "rely"; turkish[100] = "güvenmek";
            english[101] = "flexible"; turkish[101] = "esnek";
            english[102] = "temporary"; turkish[102] = "geçici";
            english[103] = "section"; turkish[103] = "bölüm";
            english[104] = "similar"; turkish[104] = "benzer";
            english[105] = "equip"; turkish[105] = "donatmak";
            english[106] = "option"; turkish[106] = "seçenek";
            english[107] = "random"; turkish[107] = "rasgele";
            english[108] = "target"; turkish[108] = "hedef";
            english[109] = "capable"; turkish[109] = "yetenekli";
            english[110] = "access"; turkish[110] = "erişim";
            english[111] = "task"; turkish[111] = "görev";
            english[112] = "stable"; turkish[112] = "kararlı";
            english[113] = "data"; turkish[113] = "veri";
            english[114] = "chapter"; turkish[114] = "bölüm";
            english[115] = "unique"; turkish[115] = "benzersiz";
            english[116] = "complex"; turkish[116] = "karmaşık";
            english[117] = "method"; turkish[117] = "yöntem";
            english[118] = "benefit"; turkish[118] = "yarar";
            english[119] = "rigid"; turkish[119] = "sert";
            english[120] = "expert"; turkish[120] = "uzman";
            english[121] = "currency"; turkish[121] = "para birimi";
            english[122] = "restrict"; turkish[122] = "kısıtlamak";
            english[123] = "available"; turkish[123] = "mevcut";
            english[124] = "document"; turkish[124] = "belge";
            english[125] = "adapt"; turkish[125] = "uyarlamak";
            english[126] = "intelligent"; turkish[126] = "zeki";
            english[127] = "react"; turkish[127] = "tepki";
            english[128] = "sum"; turkish[128] = "toplam";
            english[129] = "voluntary"; turkish[129] = "gönüllü";
            english[130] = "reinforce"; turkish[130] = "pekiştirmek";
            english[131] = "eliminate"; turkish[131] = "elemek";
            english[132] = "schedule"; turkish[132] = "program";
            english[133] = "crucial"; turkish[133] = "çok önemli";
            english[134] = "diminish"; turkish[134] = "azaltmak";
            english[135] = "consume"; turkish[135] = "tüketmek";
            english[136] = "region"; turkish[136] = "bölge";
            english[137] = "notion"; turkish[137] = "kavram";
            english[138] = "perceive"; turkish[138] = "algılamak";
            english[139] = "variable"; turkish[139] = "değişken";
            english[140] = "enable"; turkish[140] = "etkinleştirmek";
            english[141] = "utility"; turkish[141] = "fayda";
            english[142] = "estimate"; turkish[142] = "tahmin";
            english[143] = "journal"; turkish[143] = "dergi";
            english[144] = "dominant"; turkish[144] = "baskın";
            english[145] = "revenue"; turkish[145] = "gelir";
            english[146] = "image"; turkish[146] = "görüntü";
            english[147] = "consent"; turkish[147] = "izin vermek";
            english[148] = "reaction"; turkish[148] = "tepki";
            english[149] = "aspect"; turkish[149] = "görünüş";
            english[150] = "location"; turkish[150] = "konum";
            english[151] = "confine"; turkish[151] = "sınırlamak";
            english[152] = "fact"; turkish[152] = "gerçek";
            english[153] = "recovery"; turkish[153] = "kurtarma";
            english[154] = "attach"; turkish[154] = "iliştirmek";
            english[155] = "subsequent"; turkish[155] = "sonraki";
            english[156] = "phase"; turkish[156] = "evre";
            english[157] = "component"; turkish[157] = "bileşen";
            english[158] = "create"; turkish[158] = "oluşturmak";
            english[159] = "contain"; turkish[159] = "içermek";
            english[160] = "fundamental"; turkish[160] = "temel";
            english[161] = "implementation"; turkish[161] = "uygulama";
            english[162] = "diversity"; turkish[162] = "çeşitlilik";
            english[163] = "ignore"; turkish[163] = "aldırmamak";
            english[164] = "suspend"; turkish[164] = "askıya almak";
            english[165] = "investment"; turkish[165] = "yatırım";
            english[166] = "outcome"; turkish[166] = "sonuç";
            english[167] = "consumer"; turkish[167] = "tüketici";
            english[168] = "collapse"; turkish[168] = "çöküş";
            english[169] = "dimesion"; turkish[169] = "boyut";
            english[170] = "generation"; turkish[170] = "nesil";
            english[171] = "restraint"; turkish[171] = "kısıtlama";
            english[172] = "summary"; turkish[172] = "özet";
            english[173] = "overall"; turkish[173] = "tüm";
            english[174] = "innovation"; turkish[174] = "yenilik";
            english[175] = "reluctant"; turkish[175] = "gönülsüz";
            english[176] = "widespread"; turkish[176] = "yaygın";
            english[177] = "fee"; turkish[177] = "ücret";
            english[178] = "involve"; turkish[178] = "dahil";


        }
        #endregion
        #region esyalar
        private void Esyalar()
        {
            Array.Resize(ref english, 109);
            Array.Resize(ref turkish, 109);

            english[0] = "armchair"; turkish[0] = "koltuk";
            english[1] = "bed"; turkish[1] = "yatak";
            english[2] = "bookshelf"; turkish[2] = "kitaplık";
            english[3] = "chair"; turkish[3] = "sandalye";
            english[4] = "clock"; turkish[4] = "saat";
            english[5] = "mirror"; turkish[5] = "ayna";
            english[6] = "piano"; turkish[6] = "piyano";
            english[7] = "stool"; turkish[7] = "tabure";
            english[8] = "table"; turkish[8] = "masa";
            english[9] = "wardrobe"; turkish[9] = "gardırop";
            english[10] = "sofa"; turkish[10] = "kanepe";
            english[11] = "iron"; turkish[11] = "ütü";
            english[12] = "lamp"; turkish[12] = "lamba";
            english[13] = "radiator"; turkish[13] = "kalorifer";
            english[14] = "radio"; turkish[14] = "radyo";
            english[15] = "television"; turkish[15] = "televizyon";
            english[16] = "washing machine"; turkish[16] = "çamaşır makinesi";
            english[17] = "blanket"; turkish[17] = "battaniye";
            english[18] = "carpet"; turkish[18] = "halı";
            english[19] = "curtains"; turkish[19] = "perde";
            english[20] = "cushion"; turkish[20] = "yastık";
            english[21] = "pillow"; turkish[21] = "yastık";
            english[22] = "pillowcase"; turkish[22] = "yastık kılıfı";
            english[23] = "towel"; turkish[23] = "havlu";
            english[24] = "wallpaper"; turkish[24] = "duvar kağıdı";
            english[25] = "bin"; turkish[25] = "çöp kutusu";
            english[26] = "broom"; turkish[26] = "süpürge";
            english[27] = "bucket"; turkish[27] = "kova";
            english[28] = "sponge"; turkish[28] = "sünger";
            english[29] = "vase"; turkish[29] = "vazo";
            english[30] = "torch"; turkish[30] = "el feneri";
            english[31] = "key"; turkish[31] = "anahtar";
            english[32] = "refrigerator"; turkish[32] = "buzdolabı";
            english[33] = "glass"; turkish[33] = "bardak";
            english[34] = "knife"; turkish[34] = "bıçak";
            english[35] = "fork"; turkish[35] = "çatal";
            english[36] = "wall"; turkish[36] = "duvar";
            english[37] = "oven"; turkish[37] = "fırın";
            english[38] = "cup"; turkish[38] = "fincan";
            english[39] = "door"; turkish[39] = "kapı";
            english[40] = "spoon"; turkish[40] = "kaşık";
            english[41] = "candle"; turkish[41] = "mum";
            english[42] = "window"; turkish[42] = "pencere";
            english[43] = "soap"; turkish[43] = "sabun";
            english[44] = "shampoo"; turkish[44] = "şampuan";
            english[45] = "plate"; turkish[45] = "tabak";
            english[46] = "bell"; turkish[46] = "zil";
            english[47] = "hammock"; turkish[47] = "hamak";
            english[48] = "elevator"; turkish[48] = "asansör";
            english[49] = "dictionary"; turkish[49] = "sözlük";
            english[50] = "brush"; turkish[50] = "fırça";
            english[51] = "folder"; turkish[51] = "dosya";
            english[52] = "map"; turkish[52] = "harita";
            english[53] = "cable"; turkish[53] = "kablo";
            english[54] = "shoe"; turkish[54] = "ayakkabı";
            english[55] = "socks"; turkish[55] = "çorap";
            english[56] = "skirt"; turkish[56] = "etek";
            english[57] = "hat"; turkish[57] = "şapka";
            english[58] = "sunglasses"; turkish[58] = "güneş gözlüğü";
            english[59] = "necklace"; turkish[59] = "kolye";
            english[60] = "telephone"; turkish[60] = "telefon";
            english[61] = "computer"; turkish[61] = "bilgisayar";
            english[62] = "napkin"; turkish[62] = "peçete";
            english[63] = "comb"; turkish[63] = "tarak";
            english[64] = "bag"; turkish[64] = "çanta";
            english[65] = "hanger"; turkish[65] = "askı";
            english[66] = "athlete"; turkish[66] = "atlet";
            english[67] = "weft"; turkish[67] = "atkı";
            english[68] = "axe"; turkish[68] = "balta";
            english[69] = "scissors"; turkish[69] = "makas";
            english[70] = "drum"; turkish[70] = "bateri";
            english[71] = "suitcase"; turkish[71] = "bavul";
            english[72] = "beret"; turkish[72] = "bere";
            english[73] = "bottle"; turkish[73] = "şişe";
            english[74] = "wristband"; turkish[74] = "bileklik";
            english[75] = "ball"; turkish[75] = "top";
            english[76] = "bike"; turkish[76] = "bisiklet";
            english[77] = "bathrobe"; turkish[77] = "bornoz";
            english[78] = "ruler"; turkish[78] = "cetvel";
            english[79] = "bolt"; turkish[79] = "civata";
            english[80] = "wallet"; turkish[80] = "cüzdan";
            english[81] = "hammer"; turkish[81] = "çekiç";
            english[82] = "sack"; turkish[82] = "çuval";
            english[83] = "tomtom"; turkish[83] = "darbuka";
            english[84] = "magazine"; turkish[84] = "dergi";
            english[85] = "toothbrush"; turkish[85] = "diş fırçası";
            english[86] = "toothpaste"; turkish[86] = "diş macunu";
            english[87] = "binoculars"; turkish[87] = "dürbün";
            english[88] = "dress"; turkish[88] = "elbise";
            english[89] = "scarf"; turkish[89] = "eşarp";
            english[90] = "flute"; turkish[90] = "flüt";
            english[91] = "newspaper"; turkish[91] = "gazete";
            english[92] = "guitar"; turkish[92] = "gitar";
            english[93] = "shirt"; turkish[93] = "gömlek";
            english[94] = "needle"; turkish[94] = "iğne";
            english[95] = "yarn"; turkish[95] = "iplik";
            english[96] = "paper"; turkish[96] = "kağıt";
            english[97] = "keyboard"; turkish[97] = "klavye";
            english[98] = "tie"; turkish[98] = "kravat";
            english[99] = "headphone"; turkish[99] = "kulaklık";
            english[100] = "earrings"; turkish[100] = "küpe";
            english[101] = "torch"; turkish[101] = "meşale";
            english[102] = "microphone"; turkish[102] = "mikrofon";
            english[103] = "arrow"; turkish[103] = "ok";
            english[104] = "rosette"; turkish[104] = "rozet";
            english[105] = "lipstick"; turkish[105] = "ruj";
            english[106] = "umbrella"; turkish[106] = "şemsiye";
            english[107] = "telescope"; turkish[107] = "teleskop";
            english[108] = "kite"; turkish[108] = "uçurtma";


            //english[109] = "capable"; turkish[109] = "yetenekli";
            //english[110] = "access"; turkish[110] = "erişim";
            //english[111] = "task"; turkish[111] = "görev";
            //english[112] = "stable"; turkish[112] = "kararlı";
            //english[113] = "data"; turkish[113] = "veri";
            //english[114] = "chapter"; turkish[114] = "bölüm";
            //english[115] = "unique"; turkish[115] = "benzersiz";
            //english[116] = "complex"; turkish[116] = "karmaşık";
            //english[117] = "method"; turkish[117] = "yöntem";
            //english[118] = "benefit"; turkish[118] = "yarar";
            //english[119] = "rigid"; turkish[119] = "sert";
            //english[120] = "expert"; turkish[120] = "uzman";
            //english[121] = "currency"; turkish[121] = "para birimi";
            //english[122] = "restrict"; turkish[122] = "kısıtlamak";
            //english[123] = "available"; turkish[123] = "mevcut";
            //english[124] = "document"; turkish[124] = "belge";
            //english[125] = "adapt"; turkish[125] = "uyarlamak";

        }
        #endregion
        #region hayvanlar
        private void Hayvanlar()
        {
            Array.Resize(ref english, 105);
            Array.Resize(ref turkish, 105);

            english[0] = "dog"; turkish[0] = "köpek";
            english[1] = "cat"; turkish[1] = "kedi";
            english[2] = "hamster"; turkish[2] = "hamster";
            english[3] = "parrot"; turkish[3] = "papağan";
            english[4] = "fish"; turkish[4] = "balık";
            english[5] = "bird"; turkish[5] = "kuş";
            english[6] = "rabbit"; turkish[6] = "tavşan";
            english[7] = "turtle"; turkish[7] = "kaplumbağa";
            english[8] = "cow"; turkish[8] = "inek";
            english[9] = "donkey"; turkish[9] = "eşek";
            english[10] = "horse"; turkish[10] = "at";
            english[11] = "sheep"; turkish[11] = "koyun";
            english[12] = "goat"; turkish[12] = "keçi";
            english[13] = "pig"; turkish[13] = "domuz";
            english[14] = "rooster"; turkish[14] = "horoz";
            english[15] = "chicken"; turkish[15] = "tavuk";
            english[16] = "goose"; turkish[16] = "kaz";
            english[17] = "duck"; turkish[17] = "ördek";
            english[18] = "butterfly"; turkish[18] = "kelebek";
            english[19] = "bee"; turkish[19] = "arı";
            english[20] = "frog"; turkish[20] = "kurbağa";
            english[21] = "penguin"; turkish[21] = "penguen";
            english[22] = "koala"; turkish[22] = "koala";
            english[23] = "deer"; turkish[23] = "geyik";
            english[24] = "wolf"; turkish[24] = "kurt";
            english[25] = "panda"; turkish[25] = "panda";
            english[26] = "fox"; turkish[26] = "tilki";
            english[27] = "kangaroo"; turkish[27] = "kanguru";
            english[28] = "squirrel"; turkish[28] = "sincap";
            english[29] = "hedgehog"; turkish[29] = "kirpi";
            english[30] = "monkey"; turkish[30] = "maymun";
            english[31] = "peacock"; turkish[31] = "tavuskuşu";
            english[32] = "rhino"; turkish[32] = "gergedan";
            english[33] = "hippo"; turkish[33] = "su aygırı";
            english[34] = "bear"; turkish[34] = "ayı";
            english[35] = "zebra"; turkish[35] = "zebra";
            english[36] = "lizard"; turkish[36] = "kertenkelr";
            english[37] = "crocodile"; turkish[37] = "timsah";
            english[38] = "dolphin"; turkish[38] = "yunus";
            english[39] = "shark"; turkish[39] = "köpek balığı";
            english[40] = "snake"; turkish[40] = "yılan";
            english[41] = "elephant"; turkish[41] = "fil";
            english[42] = "giraffe"; turkish[42] = "zürafa";
            english[43] = "tiger"; turkish[43] = "kaplan";
            english[44] = "lion"; turkish[44] = "aslan";
            english[45] = "polar bear"; turkish[45] = "kutup ayısı";
            english[46] = "dove"; turkish[46] = "güvercin";
            english[47] = "camel"; turkish[47] = "deve";
            english[48] = "lamb"; turkish[48] = "kuzu";
            english[49] = "sparrow"; turkish[49] = "serçe";
            english[50] = "cheetah"; turkish[50] = "çita";
            english[51] = "mouse"; turkish[51] = "fare";
            english[52] = "ant"; turkish[52] = "karınca";
            english[53] = "antelope"; turkish[53] = "antilop";
            english[54] = "anaconda"; turkish[54] = "anakonda";
            english[55] = "anteater"; turkish[55] = "karıncayiyen";
            english[56] = "bat"; turkish[56] = "yarasa";
            english[57] = "beaver"; turkish[57] = "kunduz";
            english[58] = "bull"; turkish[58] = "boğa";
            english[59] = "chick"; turkish[59] = "civciv";
            english[60] = "crow"; turkish[60] = "karga";
            english[61] = "eagle"; turkish[61] = "kartal";
            english[62] = "hawk"; turkish[62] = "şahin";
            english[63] = "grasshopper"; turkish[63] = "çekirge";
            english[64] = "impala"; turkish[64] = "impala";
            english[65] = "iguana"; turkish[65] = "iguana";
            english[66] = "jackal"; turkish[66] = "çakal";
            english[67] = "jaguar"; turkish[67] = "jaguar";
            english[68] = "jellyfish"; turkish[68] = "denizanası";
            english[69] = "leopard"; turkish[69] = "leopar";
            english[70] = "lobster"; turkish[70] = "ıstakoz";
            english[71] = "mosquito"; turkish[71] = "sivrisinek";
            english[72] = "mole"; turkish[72] = "köstebek";
            english[73] = "octopus"; turkish[73] = "ahtapot";
            english[74] = "owl"; turkish[74] = "baykuş";
            english[75] = "panther"; turkish[75] = "panter";
            english[76] = "pelican"; turkish[76] = "pelikan";
            english[77] = "piranha"; turkish[77] = "pirana";
            english[78] = "python"; turkish[78] = "piton";
            english[79] = "raccoon"; turkish[79] = "rakun";
            english[80] = "rat"; turkish[80] = "sıçan";
            english[81] = "seagull"; turkish[81] = "martı";
            english[82] = "spider"; turkish[82] = "örümcek";
            english[83] = "tarantula"; turkish[83] = "tarantula";
            english[84] = "vulture"; turkish[84] = "akbaba";
            english[85] = "viper"; turkish[85] = "engerek yılanı";
            english[86] = "whale"; turkish[86] = "balina";
            english[87] = "lynx"; turkish[87] = "vaşak";
            english[88] = "chameleon"; turkish[88] = "bukalemun";
            english[89] = "pigeon"; turkish[89] = "güvercin";
            english[90] = "seal"; turkish[90] = "fok";
            english[91] = "orangutan"; turkish[91] = "orangutan";
            english[92] = "hyena"; turkish[92] = "sırtlan";
            english[93] = "gazelle"; turkish[93] = "ceylan";
            english[94] = "chimpanzee"; turkish[94] = "şempanze";
            english[95] = "badger"; turkish[95] = "porsuk";
            english[96] = "otter"; turkish[96] = "su samuru";
            english[97] = "stoat"; turkish[97] = "gelincik";
            english[98] = "weasel"; turkish[98] = "sansar";
            english[99] = "peafowl"; turkish[99] = "tavus kuşu";
            english[100] = "robin"; turkish[100] = "bülbül";
            english[101] = "swan"; turkish[101] = "kuğu";
            english[102] = "canary"; turkish[102] = "kanarya";
            english[103] = "fly"; turkish[103] = "sinek";
            english[104] = "crab"; turkish[104] = "yengeç";


        }
        #endregion
        #region ulkeler
        private void Ulkeler()
        {
            Array.Resize(ref english, 101);
            Array.Resize(ref turkish, 101);

            english[0] = "Afghanistan"; turkish[0] = "afganistan";
            english[1] = "Albania"; turkish[1] = "arnavutluk";
            english[2] = "Algeria"; turkish[2] = "cezayir";
            english[3] = "Argentina"; turkish[3] = "arjantin";
            english[4] = "Australia"; turkish[4] = "avustralya";
            english[5] = "Austria"; turkish[5] = "avusturya";
            english[6] = "Azerbaijan"; turkish[6] = "azerbaycan";
            english[7] = "Belgium"; turkish[7] = "belçika";
            english[8] = "Brazil"; turkish[8] = "brezilya";
            english[9] = "Bulgaria"; turkish[9] = "bulgaristan";
            english[10] = "Canada"; turkish[10] = "kanada";
            english[11] = "China"; turkish[11] = "çin";
            english[12] = "Luxembourg"; turkish[12] = "lüksemburg";
            english[13] = "Czech Republic"; turkish[13] = "çek cumhuriyeti";
            english[14] = "Denmark"; turkish[14] = "danimarka";
            english[15] = "Egypt"; turkish[15] = "mısır";
            english[16] = "England"; turkish[16] = "ingiltere";
            english[17] = "Finland"; turkish[17] = "finlandiya";
            english[18] = "France"; turkish[18] = "fransa";
            english[19] = "Georgia"; turkish[19] = "gürcistan";
            english[20] = "Germany"; turkish[20] = "almanya";
            english[21] = "Greece"; turkish[21] = "yunanistan";
            english[22] = "Netherlands"; turkish[22] = "hollanda";
            english[23] = "Hungary"; turkish[23] = "macaristan";
            english[24] = "India"; turkish[24] = "hindistan";
            english[25] = "Iran"; turkish[25] = "iran";
            english[26] = "Iraq"; turkish[26] = "ırak";
            english[27] = "Israel"; turkish[27] = "israil";
            english[28] = "Italy"; turkish[28] = "italya";
            english[29] = "Japan"; turkish[29] = "japonya";
            english[30] = "Jordan"; turkish[30] = "ürdün";
            english[31] = "Latvia"; turkish[31] = "letonya";
            english[32] = "Libya"; turkish[32] = "libya";
            english[33] = "Mexico"; turkish[33] = "meksika";
            english[34] = "Morocco"; turkish[34] = "fas";
            english[35] = "Pakistan"; turkish[35] = "pakistan";
            english[36] = "Poland"; turkish[36] = "polonya";
            english[37] = "Portugal"; turkish[37] = "portekiz";
            english[38] = "Romania"; turkish[38] = "romanya";
            english[39] = "Russia"; turkish[39] = "rusya";
            english[40] = "Saudi Arabia"; turkish[40] = "suudi arabistan";
            english[41] = "Scotland"; turkish[41] = "iskoçya";
            english[42] = "South Korea"; turkish[42] = "güney kore";
            english[43] = "Spain"; turkish[43] = "ispanya";
            english[44] = "Sweden"; turkish[44] = "isveç";
            english[45] = "Switzerland"; turkish[45] = "isviçre";
            english[46] = "Syria"; turkish[46] = "suriye";
            english[47] = "Thailand"; turkish[47] = "tayland";
            english[48] = "Turkey"; turkish[48] = "türkiye";
            english[49] = "Ukraine"; turkish[49] = "ukrayna";
            english[50] = "Wales"; turkish[50] = "galler";
            english[51] = "United States"; turkish[51] = "birleşik devletler";
            english[52] = "Bolivia"; turkish[52] = "bolivya";
            english[53] = "Cambodia"; turkish[53] = "kamboçya";
            english[54] = "Chile"; turkish[54] = "şili";
            english[55] = "Colombia"; turkish[55] = "kolombiya";
            english[56] = "Costa Rica"; turkish[56] = "kosta rika";
            english[57] = "Cuba"; turkish[57] = "küba";
            english[58] = "Ecuador"; turkish[58] = "ekvador";
            english[59] = "Dominican Republic"; turkish[59] = "dominik cumhuriyeti";
            english[60] = "Estonia"; turkish[60] = "estonya";
            english[61] = "Ethiopia"; turkish[61] = "etiyopya";
            english[62] = "Guatemala"; turkish[62] = "guatemala";
            english[63] = "Haiti"; turkish[63] = "haiti";
            english[64] = "Honduras"; turkish[64] = "honduras";
            english[65] = "Indonesia"; turkish[65] = "endonezya";
            english[66] = "Laos"; turkish[66] = "laos";
            english[67] = "Lithuania"; turkish[67] = "litvanya";
            english[68] = "Malaysia"; turkish[68] = "malezya";
            english[69] = "New Zealand"; turkish[69] = "yeni zelanda";
            english[70] = "Nicaragua"; turkish[70] = "nikaragua";
            english[71] = "Panama"; turkish[71] = "panama";
            english[72] = "Peru"; turkish[72] = "peru";
            english[73] = "Philippines"; turkish[73] = "filipinler";
            english[74] = "Puerto Rico"; turkish[74] = "porto riko";
            english[75] = "Taiwan"; turkish[75] = "tayvan";
            english[76] = "Venezuela"; turkish[76] = "venezüella";
            english[77] = "Vietnam"; turkish[77] = "vietnam";
            english[78] = "Northern Ireland"; turkish[78] = "kuzey irlanda";
            english[79] = "Norway"; turkish[79] = "norveç";
            english[80] = "Uruguay"; turkish[80] = "uruguay";
            english[81] = "Bangladesh"; turkish[81] = "bangladeş";
            english[82] = "Bahrain"; turkish[82] = "bahreyn";
            english[83] = "Iceland"; turkish[83] = "izlanda";
            english[84] = "Jamaica"; turkish[84] = "jamaika";
            english[85] = "Cameroon"; turkish[85] = "kamerun";
            english[86] = "Nigeria"; turkish[86] = "nijerya";
            english[87] = "Qatar"; turkish[87] = "katar";
            english[88] = "Kazakhistan"; turkish[88] = "kazakistan";
            english[89] = "Kosovo"; turkish[89] = "kosova";
            english[90] = "Macedonia"; turkish[90] = "makedonya";
            english[91] = "Mongolia"; turkish[91] = "moğolistan";
            english[92] = "Uzbekistan"; turkish[92] = "özbekistan";
            english[93] = "Slovakia"; turkish[93] = "slovakya";
            english[94] = "Slovenia"; turkish[94] = "slovenya";
            english[95] = "Tajikistan"; turkish[95] = "tacikistan";
            english[96] = "Turkmenistan"; turkish[96] = "türkmenistan";
            english[97] = "Zimbabwe"; turkish[97] = "zimbabve";
            english[98] = "Zambia"; turkish[98] = "zambiya";
            english[99] = "Rwanda"; turkish[99] = "ruanda";
            english[100] = "Montenegro"; turkish[100] = "karadağ";

        }
        #endregion
        #region yiyecekicecek
        private void YiyecekIcecek()
        {
            Array.Resize(ref english, 108);
            Array.Resize(ref turkish, 108);

            english[0] = "apple"; turkish[0] = "elma";
            english[1] = "orange"; turkish[1] = "portakal";
            english[2] = "coke"; turkish[2] = "kola";
            english[3] = "lemon"; turkish[3] = "limon";
            english[4] = "seed"; turkish[4] = "çekirdek";
            english[5] = "banana"; turkish[5] = "muz";
            english[6] = "grapes"; turkish[6] = "üzüm";
            english[7] = "raisins"; turkish[7] = "kuru üzüm";
            english[8] = "grapefruit"; turkish[8] = "greyfurt";
            english[9] = "cherry"; turkish[9] = "kiraz";
            english[10] = "sour cherry"; turkish[10] = "vişne";
            english[11] = "avocado"; turkish[11] = "avokado";
            english[12] = "peach"; turkish[12] = "şeftali";
            english[13] = "apricot"; turkish[13] = "kayısı";
            english[14] = "cantaloupe"; turkish[14] = "kavun";
            english[15] = "watermelon"; turkish[15] = "karpuz";
            english[16] = "peanut"; turkish[16] = "fıstık";
            english[17] = "strawberry"; turkish[17] = "çilek";
            english[18] = "raspberry"; turkish[18] = "ahududu";
            english[19] = "blackberry"; turkish[19] = "böğürtlen";
            english[20] = "blueberry"; turkish[20] = "yaban mersini";
            english[21] = "mulberry"; turkish[21] = "dut";
            english[22] = "coconut"; turkish[22] = "hindistan cevizi";
            english[23] = "quince"; turkish[23] = "ayva";
            english[24] = "mango"; turkish[24] = "mango";
            english[25] = "pineapple"; turkish[25] = "ananas";
            english[26] = "pomegranate"; turkish[26] = "nar";
            english[27] = "chestnuts"; turkish[27] = "kestane";
            english[28] = "tangerine"; turkish[28] = "mandalina";
            english[29] = "pear"; turkish[29] = "armut";
            english[30] = "fig"; turkish[30] = "incir";
            english[31] = "plum"; turkish[31] = "erik";
            english[32] = "asparagus"; turkish[32] = "kuşkonmaz";
            english[33] = "artichoke"; turkish[33] = "enginar";
            english[34] = "peas"; turkish[34] = "bezelye";
            english[35] = "radish"; turkish[35] = "turp";
            english[36] = "beet"; turkish[36] = "pancar";
            english[37] = "pumpkin"; turkish[37] = "balkabağı";
            english[38] = "zucchini"; turkish[38] = "kabak";
            english[39] = "cucumber"; turkish[39] = "salatalık";
            english[40] = "pepper"; turkish[40] = "biber";
            english[41] = "beans"; turkish[41] = "fasulye";
            english[42] = "aubergine"; turkish[42] = "patlıcan";
            english[43] = "garlic"; turkish[43] = "sarımsak";
            english[44] = "cauliflower"; turkish[44] = "karnabahar";
            english[45] = "broccoli"; turkish[45] = "brokoli";
            english[46] = "celery"; turkish[46] = "kereviz";
            english[47] = "carrot"; turkish[47] = "havuç";
            english[48] = "potato"; turkish[48] = "patates";
            english[49] = "onion"; turkish[49] = "soğan";
            english[50] = "mushroom"; turkish[50] = "mantar";
            english[51] = "cabbage"; turkish[51] = "lahana";
            english[52] = "lettuce"; turkish[52] = "marul";
            english[53] = "corn"; turkish[53] = "mısır";
            english[54] = "turnip"; turkish[54] = "turp";
            english[55] = "tomato"; turkish[55] = "domates";
            english[56] = "bread"; turkish[56] = "ekmek";
            english[57] = "soup"; turkish[57] = "çorba";
            english[58] = "dessert"; turkish[58] = "tatlı";
            english[59] = "jam"; turkish[59] = "reçel";
            english[60] = "wheat"; turkish[60] = "buğday";
            english[61] = "barley"; turkish[61] = "arpa";
            english[62] = "rice"; turkish[62] = "pirinç";
            english[63] = "noodles"; turkish[63] = "erişte";
            english[64] = "pasta"; turkish[64] = "makarna";
            english[65] = "milk"; turkish[65] = "süt";
            english[66] = "butter"; turkish[66] = "tereyağı";
            english[67] = "yoghurt"; turkish[67] = "yoğurt";
            english[68] = "cheese"; turkish[68] = "peynir";
            english[69] = "olive"; turkish[69] = "zeytin";
            english[70] = "almond"; turkish[70] = "badem";
            english[71] = "chestnut"; turkish[71] = "kestane";
            english[72] = "walnut"; turkish[72] = "ceviz";
            english[73] = "hazelnut"; turkish[73] = "fındık";
            english[74] = "pistachio"; turkish[74] = "antep fıstığı";
            english[75] = "egg"; turkish[75] = "yumurta";
            english[76] = "yolk"; turkish[76] = "yumurta sarısı";
            english[77] = "scrambled eggs"; turkish[77] = "omlet";
            english[78] = "meat"; turkish[78] = "et";
            english[79] = "sausage"; turkish[79] = "sosis";
            english[80] = "steak"; turkish[80] = "biftek";
            english[81] = "french fries"; turkish[81] = "patates kızartması";
            english[82] = "salt"; turkish[82] = "tuz";
            english[83] = "black pepper"; turkish[83] = "karabiber";
            english[84] = "ketchup"; turkish[84] = "ketçap";
            english[85] = "mustard"; turkish[85] = "hardal";
            english[86] = "mayonnaise"; turkish[86] = "mayonez";
            english[87] = "pickle"; turkish[87] = "turşu";
            english[88] = "honey"; turkish[88] = "bal";
            english[89] = "popcorn"; turkish[89] = "patlamış mısır";
            english[90] = "sugar"; turkish[90] = "şeker";
            english[91] = "chocolate"; turkish[91] = "çikolata";
            english[92] = "cake"; turkish[92] = "pasta";
            english[93] = "cookie"; turkish[93] = "kurabiye";
            english[94] = "pie"; turkish[94] = "turta";
            english[95] = "gum"; turkish[95] = "sakız";
            english[96] = "ice-cream"; turkish[96] = "dondurma";
            english[97] = "water"; turkish[97] = "su";
            english[98] = "coffee"; turkish[98] = "kahve";
            english[99] = "tea"; turkish[99] = "çay";
            english[100] = "hot chocolate"; turkish[100] = "sıcak çikolata";
            english[101] = "orange juice"; turkish[101] = "portakal suyu";
            english[102] = "juice"; turkish[102] = "meyve suyu";
            english[103] = "mineral water"; turkish[103] = "maden suyu";
            english[104] = "lemonade"; turkish[104] = "limonata";
            english[105] = "wine"; turkish[105] = "şarap";
            english[106] = "beer"; turkish[106] = "bira";
            english[107] = "whiskey"; turkish[107] = "viski";

        }
        #endregion
        public void AynıKelimeZatenMevcut()
        {
            label8.Visible = true;
        }

        public bool ulkeisimleri = false;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Application.StartupPath + "\\newcur.cur");
            this.Cursor = Cursor.Current;


            textBox2.Text = "buraya yazın";
            textBox2.ForeColor = Color.Gainsboro;

            kk.Show();
            kk.Hide();
            if (kategori=="gundelik")
            {
                Gundelik();
            }
            else if (kategori == "akademik")
            {
                Akademik();
            }
            else if (kategori == "esyalar")
            {
                Esyalar();
            }
            else if (kategori == "hayvanlar")
            {
                Hayvanlar();
            }
            else if (kategori == "ulkeler")
            {
                Ulkeler();
                ulkeisimleri = true;

            }
            else if (kategori == "yiyecekicecek")
            {
                YiyecekIcecek();
            }

            label3.Visible = false;
            label2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            

            bool muzikkapa = true;
            Form3 frmm3 = new Form3(muzikkapa);
            frmm3.MuzikKapa();
            
            

            int sayac = 0;
            if (sayac==0)
            {
                label4.Text = rnd.Next(0, english.Length).ToString();
                sayac++;
                

            }


            label1.Visible = true;

            label4.Visible = false;
            

        }
        

        bool bitirmesesi = false;
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.ToLower(new CultureInfo("tr-TR",false)) == turkish[int.Parse(label4.Text)])
            {
                english[int.Parse(label4.Text)] = null;     //burada Form1_Load'da oluşturduğumuz random gelen dizi elemanını null yapıyoruz.
                
                label3.Visible = true;    //eğer yanıt doğruysa Doğru! true olacak yani gözükecek
                label2.Visible = false;   //diğeri false olacak

                
                label4.Text = rnd.Next(0, english.Length).ToString();     //burda random dizi seçiyoruz
                label1.Text = english[int.Parse(label4.Text)];

                
                if (english[int.Parse(label4.Text)] == null)       //seçtiğimiz dizi eğer null ise if'e gir
                {
                    while (english[int.Parse(label4.Text)] == null)    //dizi null olduğu sürece whileda dön
                    {
                        int sayacc = 0;
                        label4.Text = rnd.Next(0, english.Length).ToString();   //ve yeni bir random sayı ata
                        label1.Text = english[int.Parse(label4.Text)];
                        for (int j = 0; j < english.Length; j++)      //en son hepsi null olduğu için while sonsuz döngüye girecek bunu durdurmak için,
                        {                                             //for döngüsüyle dizinin bütün elemanlarını kontrol ediyorum.
                                                                      
                            if (english[j]==null)                     //dizi elemanı kadar sayacc varsa bu demek oluyor ki hepsi null
                            {
                                sayacc++;
                            }
                        }
                        if (sayacc==english.Length)                 //o halde sayac, dizi eleman sayısına eşitse if'e gir ve döngüyü kır(break)
                        {
                            kategorifinish kf = new kategorifinish();
                            kf.Show();
                            button1.Enabled = false;
                            button2.Enabled = false;
                            button3.Enabled = false;
                            button6.Enabled = false;
                            button4.Enabled = false;
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;

                            bitirmesesi = true;

                            break;
                        }
                    }
                    
                }

                english[int.Parse(label4.Text)] = null;
                


                puan++;
                

                if (seslendirme)
                {
                    if (puan == 1&&yanlissayisi==0)
                    {
                        okuyucu.Dispose();
                        okuyucu = new SpeechSynthesizer();
                        okuyucu.SpeakAsync("Good Start!Keepgoinglike that!");
                    }
                    else if (bitirmesesi)
                    {
                        okuyucu.Dispose();
                        okuyucu = new SpeechSynthesizer();
                        okuyucu.SpeakAsync("Congratulations!You have completed this category!");
                    }
                    else if (puan%10==0)
                    {
                        okuyucu.Dispose();
                        okuyucu = new SpeechSynthesizer();
                        okuyucu.SpeakAsync("Excellent!");
                    }
                    else if (puan%5==0)
                    {
                        okuyucu.Dispose();
                        okuyucu = new SpeechSynthesizer();
                        okuyucu.SpeakAsync("Very Good!");
                    }
                    else
                    {
                        okuyucu.Dispose();
                        okuyucu = new SpeechSynthesizer();
                        okuyucu.SpeakAsync("Correct!");
                    }
                }
                
                label5.Text = puan.ToString();


                textBox2.Text = "";     //bir sonraki kelimeye geçmeden önce textbox2'yi boşaltıyorum
                textBox2.Focus();
            }
            else if (textBox2.Text=="")
            {
                label10.Visible = true;
            }
            else
            {
                yanlissayisi++;
                if (seslendirme)
                {
                    if (yanlissayisi%3==0)
                    {
                        okuyucu.Dispose();
                        okuyucu = new SpeechSynthesizer();
                        okuyucu.SpeakAsync("Be more careful!");
                    }
                    else
                    {
                        okuyucu.Dispose();
                        okuyucu = new SpeechSynthesizer();
                        okuyucu.SpeakAsync("Wrong!");
                    }
                }
                
                
                
                

                label6.Text = yanlissayisi.ToString();
                label3.Visible = false;   //bu false olacak
                label2.Visible = true;    //eğer yanıt yanlışsa Yanlış! true olacak yani gözükecek

                textBox2.Focus();
            }
            



        }

        private void label1_VisibleChanged(object sender, EventArgs e)
        {
            label1.Text = english[int.Parse(label4.Text)];
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Buradan....
            if (char.IsPunctuation(e.KeyChar))      //özel karakter girilmesini engeller.
            {
                e.Handled = true;
            }
            if (char.IsSymbol(e.KeyChar))    //semol girilmesini engeller.
            {
                e.Handled = true;
            }
            //Buraya kadar özel karakterlerin ve sembollerin girilmesini engeller.
            

            ///////////sayı girmemeli
            if (e.KeyChar==(char)Keys.D0)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.D9)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.D8)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.D7)
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (char)Keys.D6)
            {
                e.Handled = true;
            }
            //////////////sayı girmemeli

            label3.Visible = false;        //yeni kelime için yazmaya başlayınca ikiside false olsun.
            label2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;   //handled kodu aynı textbox içinde kalmamı sağlıyor. Bu sayede "Ding" sesi gelmemiş oluyor.
                button1.PerformClick();
            }
            else if (e.KeyChar==(char)Keys.D1)
            {
                textBox3.Focus();
                e.Handled = true;
                button3.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D2)
            {
                e.Handled = true;
                button2.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D3)
            {
                e.Handled = true;
                button4.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D4)
            {
                e.Handled = true;
                button6.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D5)
            {
                e.Handled = true;
                button8.PerformClick();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Visible = false;        //sonraki butonuna basınca ikiside false olsun.
            label2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;


            textBox2.Enabled = true;     //texbox2'yi aktif hale getiriyorum tekrardan
            textBox2.ForeColor = Color.White;       //cevap butonunda yeşil olan yazı rengini burada tekrar eski haline döndürdüm.
            textBox2.Text = "";           //ileri butonuna basınca önceki cevap textbox'ta kalmasın temizlensin
            button1.Enabled = true;       //ileri butonuna basınca gönder butonu tekrar aktif hale gelsin.
            textBox2.Focus();     //ileri butonuna bastıktan sonra'da textbox2'de imleç yansın.

            english[int.Parse(label4.Text)] = null;

            label4.Text = rnd.Next(0, english.Length).ToString();
            label1.Text = english[int.Parse(label4.Text)];

            if (english[int.Parse(label4.Text)] == null)       //seçtiğimiz dizi eğer null ise if'e gir
            {
                
                while (english[int.Parse(label4.Text)] == null)    //dizi null olduğu sürece whileda dön
                {
                    int sayacc = 0;
                    label4.Text = rnd.Next(0, english.Length).ToString();   //ve yeni bir random sayı ata
                    label1.Text = english[int.Parse(label4.Text)];
                    for (int j = 0; j < english.Length; j++)      //en son hepsi null olduğu için while sonsuz döngüye girecek bunu durdurmak için,
                    {                                             //for döngüsüyle dizinin bütün elemanlarını kontrol ediyorum.

                        if (english[j] == null)                     //dizi elemanı kadar sayacc varsa bu demek oluyor ki hepsi null
                        {
                            sayacc++;
                        }
                    }
                    if (sayacc == english.Length)                 //o halde sayac, dizi eleman sayısına eşitse if'e gir ve döngüyü kır(break)
                    {
                        kategorifinish kf = new kategorifinish();
                        kf.Show();
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button6.Enabled = false;
                        button4.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        bitirmesesi = true;
                        break;
                    }
                }

            }
            english[int.Parse(label4.Text)] = null;

        }

        CultureInfo ci=new CultureInfo("tr-TR",false);
        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;        //cevabı gör butonuna basınca ikiside false olsun.
            label2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;

            textBox2.Text = ci.TextInfo.ToTitleCase(turkish[int.Parse(label4.Text)]);
            button1.Enabled = false;     //gönder butonunu pasif yapıyorum çünkü cevap çıkınca göndere basıp puan alamasın diye
            textBox2.ForeColor = Color.White;   //cevabın yeşil gözükmesini istiyorum daha sonra buton2 de bunu eski haline getireceğim. Sadece Cevap butonuna basınca yeşil olmasını istiyorum.
            textBox2.Enabled = false;   //textbox2'yi pasif hale getiriyorum.
            textBox3.Focus();
        }



        
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = Color.White;
            if (label1.Text != "")
            {
                okuyucu.Dispose();
                okuyucu = new SpeechSynthesizer();
                okuyucu.SpeakAsync(label1.Text);
            }
            textBox2.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (arkaplanmuzik)
            {
                bool muzikkapa = false;
                Form3 frm3 = new Form3(muzikkapa);
                frm3.MuzikAc();
            }

            kk.Kaydet();

            Form2 geri = new Form2(seslendirme,arkaplanmuzik);
            geri.Show();
            this.Hide();
        }
        
        
        private void button7_Click(object sender, EventArgs e)
        {
            exitmenu exit = new exitmenu();
            exit.Show();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D2)
            {
                textBox3.Text = "";
                e.Handled = true;
                button2.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D3)
            {
                e.Handled = true;
                button4.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D4)
            {
                e.Handled = true;
                button6.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D5)
            {
                e.Handled = true;
                button8.PerformClick();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            kisayoltuslari ksyl = new kisayoltuslari();
            ksyl.Show();
        }



        kaydedilmiskelimeler kk = new kaydedilmiskelimeler();
        string engg;
        string trr;
        private void button6_Click(object sender, EventArgs e)
        {

            if (ulkeisimleri)
            {
                kk.UlkeIsımleri(ulkeisimleri);
            }

            engg = label1.Text;
            trr = turkish[int.Parse(label4.Text)];
            kk.KelimeEkle(engg,trr);
            textBox2.Focus();
            if (kk.kirksekizoldu)
            {
                label9.Visible = true;
            }
            else if (kk.kontrol)
            {
                label8.Visible = true;
                if (seslendirme)
                {
                    okuyucu.Dispose();
                    okuyucu = new SpeechSynthesizer();
                    okuyucu.SpeakAsync("You Have Previously Appended!");
                }
                
            }
            else
            {
                label7.Visible = true;
                if (seslendirme)
                {
                    okuyucu.Dispose();
                    okuyucu = new SpeechSynthesizer();
                    okuyucu.SpeakAsync("You Have Appended!");
                }
                
            }
            
            
        }
        
        private void button8_Click(object sender, EventArgs e)
        {
            kk.SiraKontrol();
            label9.Visible = false;
            kk.ElemanKontrol();
            if (kk.elemansayisi != 0)
            {
                kk.ElemanVar();

            }
            else
            {
                kk.ElemanYok();
            }
            kk.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
