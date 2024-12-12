; ModuleID = 'obj\Debug\110\android\marshal_methods.x86_64.ll'
source_filename = "obj\Debug\110\android\marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [194 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 14
	i64 210515253464952879, ; 1: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 47
	i64 232391251801502327, ; 2: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 71
	i64 295915112840604065, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 72
	i64 634308326490598313, ; 4: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 62
	i64 702024105029695270, ; 5: System.Drawing.Common => 0x9be17343c0e7726 => 2
	i64 720058930071658100, ; 6: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 56
	i64 872800313462103108, ; 7: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 53
	i64 940822596282819491, ; 8: System.Transactions => 0xd0e792aa81923a3 => 88
	i64 996343623809489702, ; 9: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 83
	i64 1000557547492888992, ; 10: Mono.Security.dll => 0xde2b1c9cba651a0 => 95
	i64 1120440138749646132, ; 11: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 85
	i64 1315114680217950157, ; 12: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 42
	i64 1425944114962822056, ; 13: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 4
	i64 1587344118459183377, ; 14: LiveChartsCore => 0x16076110cd10b111 => 9
	i64 1624659445732251991, ; 15: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 40
	i64 1628611045998245443, ; 16: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 64
	i64 1636321030536304333, ; 17: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 57
	i64 1731380447121279447, ; 18: Newtonsoft.Json => 0x18071957e9b889d7 => 16
	i64 1743969030606105336, ; 19: System.Memory.dll => 0x1833d297e88f2af8 => 28
	i64 1795316252682057001, ; 20: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 41
	i64 1836611346387731153, ; 21: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 71
	i64 1865037103900624886, ; 22: Microsoft.Bcl.AsyncInterfaces => 0x19e1f15d56eb87f6 => 13
	i64 1875917498431009007, ; 23: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 38
	i64 1981742497975770890, ; 24: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 63
	i64 2040001226662520565, ; 25: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 96
	i64 2133195048986300728, ; 26: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 16
	i64 2134971073272545971, ; 27: Microsoft.AspNet.SignalR.Client.dll => 0x1da0f0e12c2502b3 => 12
	i64 2136356949452311481, ; 28: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 68
	i64 2165725771938924357, ; 29: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 45
	i64 2188974421706709258, ; 30: SkiaSharp.HarfBuzz.dll => 0x1e60cca38c3e990a => 21
	i64 2262844636196693701, ; 31: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 53
	i64 2284400282711631002, ; 32: System.Web.Services => 0x1fb3d1f42fd4249a => 93
	i64 2329709569556905518, ; 33: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 60
	i64 2335503487726329082, ; 34: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 33
	i64 2337758774805907496, ; 35: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 31
	i64 2470498323731680442, ; 36: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 48
	i64 2479423007379663237, ; 37: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 75
	i64 2497223385847772520, ; 38: System.Runtime => 0x22a7eb7046413568 => 32
	i64 2547086958574651984, ; 39: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 37
	i64 2592350477072141967, ; 40: System.Xml.dll => 0x23f9e10627330e8f => 35
	i64 2624866290265602282, ; 41: mscorlib.dll => 0x246d65fbde2db8ea => 15
	i64 2656887725396248467, ; 42: S7.Net => 0x24df294f3856c793 => 19
	i64 2783046991838674048, ; 43: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 31
	i64 2960931600190307745, ; 44: Xamarin.Forms.Core => 0x2917579a49927da1 => 81
	i64 3017704767998173186, ; 45: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 85
	i64 3289520064315143713, ; 46: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 59
	i64 3303437397778967116, ; 47: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 39
	i64 3311221304742556517, ; 48: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 30
	i64 3446944858302542142, ; 49: LiveChartsCore.dll => 0x2fd60215ff7b713e => 9
	i64 3461602852075779363, ; 50: SkiaSharp.HarfBuzz => 0x300a15741f74b523 => 21
	i64 3522470458906976663, ; 51: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 73
	i64 3531994851595924923, ; 52: System.Numerics => 0x31042a9aade235bb => 29
	i64 3571415421602489686, ; 53: System.Runtime.dll => 0x319037675df7e556 => 32
	i64 3716579019761409177, ; 54: netstandard.dll => 0x3393f0ed5c8c5c99 => 1
	i64 3727469159507183293, ; 55: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 70
	i64 3966267475168208030, ; 56: System.Memory => 0x370b03412596249e => 28
	i64 4525561845656915374, ; 57: System.ServiceModel.Internals => 0x3ece06856b710dae => 94
	i64 4636684751163556186, ; 58: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 77
	i64 4782108999019072045, ; 59: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 44
	i64 4794310189461587505, ; 60: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 37
	i64 4795410492532947900, ; 61: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 73
	i64 5142919913060024034, ; 62: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 82
	i64 5203618020066742981, ; 63: Xamarin.Essentials => 0x4836f704f0e652c5 => 80
	i64 5205316157927637098, ; 64: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 66
	i64 5348796042099802469, ; 65: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 67
	i64 5376510917114486089, ; 66: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 75
	i64 5408338804355907810, ; 67: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 74
	i64 5507995362134886206, ; 68: System.Core.dll => 0x4c705499688c873e => 25
	i64 5692067934154308417, ; 69: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 79
	i64 5896680224035167651, ; 70: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 61
	i64 5987624524634945836, ; 71: LiveChartsCore.SkiaSharpView.XamarinForms.dll => 0x531850c80748792c => 11
	i64 6085203216496545422, ; 72: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 83
	i64 6086316965293125504, ; 73: FormsViewGroup.dll => 0x5476f10882baef80 => 6
	i64 6222399776351216807, ; 74: System.Text.Json.dll => 0x565a67a0ffe264a7 => 34
	i64 6319713645133255417, ; 75: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 62
	i64 6401687960814735282, ; 76: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 60
	i64 6504860066809920875, ; 77: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 45
	i64 6548213210057960872, ; 78: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 51
	i64 6591024623626361694, ; 79: System.Web.Services.dll => 0x5b7805f9751a1b5e => 93
	i64 6659513131007730089, ; 80: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 56
	i64 6671798237668743565, ; 81: SkiaSharp => 0x5c96fd260152998d => 20
	i64 6763861193558508191, ; 82: System.IO.Ports => 0x5dde0feb481ac29f => 27
	i64 6805856223876288131, ; 83: AppSCADA.dll => 0x5e73422d38870e83 => 5
	i64 6876862101832370452, ; 84: System.Xml.Linq => 0x5f6f85a57d108914 => 36
	i64 6894844156784520562, ; 85: System.Numerics.Vectors => 0x5faf683aead1ad72 => 30
	i64 7036436454368433159, ; 86: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 58
	i64 7103753931438454322, ; 87: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 55
	i64 7234284632499269838, ; 88: LiveChartsCore.SkiaSharpView => 0x6465578b5c2fb0ce => 10
	i64 7488575175965059935, ; 89: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 36
	i64 7576191739629449958, ; 90: Microsoft.AspNet.SignalR.Client => 0x69240a3f2edcb2e6 => 12
	i64 7635363394907363464, ; 91: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 81
	i64 7637365915383206639, ; 92: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 80
	i64 7654504624184590948, ; 93: System.Net.Http => 0x6a3a4366801b8264 => 3
	i64 7820441508502274321, ; 94: System.Data => 0x6c87ca1e14ff8111 => 87
	i64 7836164640616011524, ; 95: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 40
	i64 7927939710195668715, ; 96: SkiaSharp.Views.Android.dll => 0x6e05b32992ed16eb => 22
	i64 8044118961405839122, ; 97: System.ComponentModel.Composition => 0x6fa2739369944712 => 92
	i64 8083354569033831015, ; 98: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 59
	i64 8103644804370223335, ; 99: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 89
	i64 8167236081217502503, ; 100: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 8
	i64 8187102936927221770, ; 101: SkiaSharp.Views.Forms => 0x719e6ebe771ab80a => 23
	i64 8601935802264776013, ; 102: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 74
	i64 8626175481042262068, ; 103: Java.Interop => 0x77b654e585b55834 => 8
	i64 8684531736582871431, ; 104: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 91
	i64 9312692141327339315, ; 105: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 79
	i64 9324707631942237306, ; 106: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 41
	i64 9662334977499516867, ; 107: System.Numerics.dll => 0x8617827802b0cfc3 => 29
	i64 9678050649315576968, ; 108: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 48
	i64 9711637524876806384, ; 109: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 67
	i64 9808709177481450983, ; 110: Mono.Android.dll => 0x881f890734e555e7 => 14
	i64 9834056768316610435, ; 111: System.Transactions.dll => 0x8879968718899783 => 88
	i64 9998632235833408227, ; 112: Mono.Security => 0x8ac2470b209ebae3 => 95
	i64 10038780035334861115, ; 113: System.Net.Http.dll => 0x8b50e941206af13b => 3
	i64 10200072684231079950, ; 114: System.IO.Ports.dll => 0x8d8df01062c2380e => 27
	i64 10229024438826829339, ; 115: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 51
	i64 10430153318873392755, ; 116: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 49
	i64 10432133507251734796, ; 117: LiveChartsCore.SkiaSharpView.XamarinForms => 0x90c662272d30890c => 11
	i64 10447083246144586668, ; 118: Microsoft.Bcl.AsyncInterfaces.dll => 0x90fb7edc816203ac => 13
	i64 10847732767863316357, ; 119: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 42
	i64 10928221405700381289, ; 120: AppSCADA.Android.dll => 0x97a8d777e1975a69 => 0
	i64 11023048688141570732, ; 121: System.Core => 0x98f9bc61168392ac => 25
	i64 11037814507248023548, ; 122: System.Xml => 0x992e31d0412bf7fc => 35
	i64 11162124722117608902, ; 123: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 78
	i64 11340910727871153756, ; 124: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 50
	i64 11392833485892708388, ; 125: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 69
	i64 11529969570048099689, ; 126: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 78
	i64 11575476872818742106, ; 127: LiveChartsCore.SkiaSharpView.dll => 0xa0a45ae2e61c535a => 10
	i64 11578238080964724296, ; 128: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 58
	i64 11580057168383206117, ; 129: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 38
	i64 11597940890313164233, ; 130: netstandard => 0xa0f429ca8d1805c9 => 1
	i64 11672361001936329215, ; 131: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 55
	i64 11826726057156489755, ; 132: AppSCADA.Android => 0xa420f8b034ab321b => 0
	i64 12102847907131387746, ; 133: System.Buffers => 0xa7f5f40c43256f62 => 24
	i64 12137774235383566651, ; 134: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 76
	i64 12145679461940342714, ; 135: System.Text.Json => 0xa88e1f1ebcb62fba => 34
	i64 12451044538927396471, ; 136: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 54
	i64 12466513435562512481, ; 137: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 65
	i64 12487638416075308985, ; 138: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 52
	i64 12538491095302438457, ; 139: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 46
	i64 12550732019250633519, ; 140: System.IO.Compression => 0xae2d28465e8e1b2f => 90
	i64 12700543734426720211, ; 141: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 47
	i64 12953969983053113793, ; 142: Prism.Forms => 0xb3c5bf1106f429c1 => 18
	i64 12963446364377008305, ; 143: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 2
	i64 13106026140046202731, ; 144: HarfBuzzSharp.dll => 0xb5e1f555ee70176b => 7
	i64 13196197655982686080, ; 145: Prism => 0xb7224fda06b0bf80 => 17
	i64 13370592475155966277, ; 146: System.Runtime.Serialization => 0xb98de304062ea945 => 4
	i64 13401370062847626945, ; 147: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 76
	i64 13454009404024712428, ; 148: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 86
	i64 13491513212026656886, ; 149: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 43
	i64 13492263892638604996, ; 150: SkiaSharp.Views.Forms.dll => 0xbb3e2686788d9ec4 => 23
	i64 13572454107664307259, ; 151: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 70
	i64 13647894001087880694, ; 152: System.Data.dll => 0xbd670f48cb071df6 => 87
	i64 13959074834287824816, ; 153: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 54
	i64 13967638549803255703, ; 154: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 82
	i64 14124974489674258913, ; 155: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 46
	i64 14159355758427094289, ; 156: S7.Net.dll => 0xc480230af56dbd11 => 19
	i64 14172845254133543601, ; 157: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 68
	i64 14261073672896646636, ; 158: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 69
	i64 14486659737292545672, ; 159: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 61
	i64 14551742072151931844, ; 160: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 33
	i64 14644440854989303794, ; 161: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 66
	i64 14792063746108907174, ; 162: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 86
	i64 14852515768018889994, ; 163: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 50
	i64 14931407803744742450, ; 164: HarfBuzzSharp => 0xcf3704499ab36c32 => 7
	i64 14987728460634540364, ; 165: System.IO.Compression.dll => 0xcfff1ba06622494c => 90
	i64 14988210264188246988, ; 166: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 52
	i64 15370334346939861994, ; 167: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 49
	i64 15582737692548360875, ; 168: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 64
	i64 15609085926864131306, ; 169: System.dll => 0xd89e9cf3334914ea => 26
	i64 15777549416145007739, ; 170: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 72
	i64 15810740023422282496, ; 171: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 84
	i64 15963349826457351533, ; 172: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 96
	i64 16035518054986892682, ; 173: Prism.dll => 0xde899ab610db458a => 17
	i64 16154507427712707110, ; 174: System => 0xe03056ea4e39aa26 => 26
	i64 16324796876805858114, ; 175: SkiaSharp.dll => 0xe28d5444586b6342 => 20
	i64 16565028646146589191, ; 176: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 92
	i64 16822611501064131242, ; 177: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 89
	i64 16833383113903931215, ; 178: mscorlib => 0xe99c30c1484d7f4f => 15
	i64 17024911836938395553, ; 179: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 39
	i64 17037200463775726619, ; 180: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 57
	i64 17544493274320527064, ; 181: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 44
	i64 17671790519499593115, ; 182: SkiaSharp.Views.Android => 0xf53ecfd92be3959b => 22
	i64 17704177640604968747, ; 183: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 65
	i64 17710060891934109755, ; 184: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 63
	i64 17741904902807664472, ; 185: AppSCADA => 0xf637e8822a9cb758 => 5
	i64 17838668724098252521, ; 186: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 24
	i64 17882897186074144999, ; 187: FormsViewGroup => 0xf82cd03e3ac830e7 => 6
	i64 17892495832318972303, ; 188: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 84
	i64 17928294245072900555, ; 189: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 91
	i64 18116111925905154859, ; 190: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 43
	i64 18129453464017766560, ; 191: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 94
	i64 18380184030268848184, ; 192: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 77
	i64 18434045720645380019 ; 193: Prism.Forms.dll => 0xffd2e2ea4860a7b3 => 18
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [194 x i32] [
	i32 14, i32 47, i32 71, i32 72, i32 62, i32 2, i32 56, i32 53, ; 0..7
	i32 88, i32 83, i32 95, i32 85, i32 42, i32 4, i32 9, i32 40, ; 8..15
	i32 64, i32 57, i32 16, i32 28, i32 41, i32 71, i32 13, i32 38, ; 16..23
	i32 63, i32 96, i32 16, i32 12, i32 68, i32 45, i32 21, i32 53, ; 24..31
	i32 93, i32 60, i32 33, i32 31, i32 48, i32 75, i32 32, i32 37, ; 32..39
	i32 35, i32 15, i32 19, i32 31, i32 81, i32 85, i32 59, i32 39, ; 40..47
	i32 30, i32 9, i32 21, i32 73, i32 29, i32 32, i32 1, i32 70, ; 48..55
	i32 28, i32 94, i32 77, i32 44, i32 37, i32 73, i32 82, i32 80, ; 56..63
	i32 66, i32 67, i32 75, i32 74, i32 25, i32 79, i32 61, i32 11, ; 64..71
	i32 83, i32 6, i32 34, i32 62, i32 60, i32 45, i32 51, i32 93, ; 72..79
	i32 56, i32 20, i32 27, i32 5, i32 36, i32 30, i32 58, i32 55, ; 80..87
	i32 10, i32 36, i32 12, i32 81, i32 80, i32 3, i32 87, i32 40, ; 88..95
	i32 22, i32 92, i32 59, i32 89, i32 8, i32 23, i32 74, i32 8, ; 96..103
	i32 91, i32 79, i32 41, i32 29, i32 48, i32 67, i32 14, i32 88, ; 104..111
	i32 95, i32 3, i32 27, i32 51, i32 49, i32 11, i32 13, i32 42, ; 112..119
	i32 0, i32 25, i32 35, i32 78, i32 50, i32 69, i32 78, i32 10, ; 120..127
	i32 58, i32 38, i32 1, i32 55, i32 0, i32 24, i32 76, i32 34, ; 128..135
	i32 54, i32 65, i32 52, i32 46, i32 90, i32 47, i32 18, i32 2, ; 136..143
	i32 7, i32 17, i32 4, i32 76, i32 86, i32 43, i32 23, i32 70, ; 144..151
	i32 87, i32 54, i32 82, i32 46, i32 19, i32 68, i32 69, i32 61, ; 152..159
	i32 33, i32 66, i32 86, i32 50, i32 7, i32 90, i32 52, i32 49, ; 160..167
	i32 64, i32 26, i32 72, i32 84, i32 96, i32 17, i32 26, i32 20, ; 168..175
	i32 92, i32 89, i32 15, i32 39, i32 57, i32 44, i32 22, i32 65, ; 176..183
	i32 63, i32 5, i32 24, i32 6, i32 84, i32 91, i32 43, i32 94, ; 184..191
	i32 77, i32 18 ; 192..193
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
