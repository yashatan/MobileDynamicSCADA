; ModuleID = 'obj\Debug\110\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\110\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [196 x i32] [
	i32 10266594, ; 0: LiveChartsCore.SkiaSharpView.dll => 0x9ca7e2 => 11
	i32 32687329, ; 1: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 63
	i32 34715100, ; 2: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 87
	i32 39109920, ; 3: Newtonsoft.Json.dll => 0x254c520 => 17
	i32 57263871, ; 4: Xamarin.Forms.Core.dll => 0x369c6ff => 82
	i32 101534019, ; 5: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 73
	i32 120558881, ; 6: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 73
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 48
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 74
	i32 205525720, ; 9: AppSCADA.Android => 0xc4012d8 => 0
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 46
	i32 230216969, ; 11: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 58
	i32 232815796, ; 12: System.Web.Services => 0xde07cb4 => 94
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 62
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 56
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 38
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 30
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 60
	i32 385762202, ; 18: System.Memory.dll => 0x16fe439a => 29
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 81
	i32 450948140, ; 20: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 55
	i32 465846621, ; 21: mscorlib => 0x1bc4415d => 16
	i32 469710990, ; 22: System.dll => 0x1bff388e => 27
	i32 476646585, ; 23: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 56
	i32 486930444, ; 24: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 67
	i32 501000162, ; 25: Prism.dll => 0x1ddca7e2 => 18
	i32 525008092, ; 26: SkiaSharp.dll => 0x1f4afcdc => 21
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 89
	i32 548916678, ; 28: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 14
	i32 605376203, ; 29: System.IO.Compression.FileSystem => 0x24154ecb => 92
	i32 614698120, ; 30: EasyModbus.dll => 0x24a38c88 => 2
	i32 627609679, ; 31: Xamarin.AndroidX.CustomView => 0x2568904f => 52
	i32 662205335, ; 32: System.Text.Encodings.Web.dll => 0x27787397 => 34
	i32 663517072, ; 33: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 78
	i32 666292255, ; 34: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 43
	i32 690569205, ; 35: System.Xml.Linq.dll => 0x29293ff5 => 37
	i32 775507847, ; 36: System.IO.Compression => 0x2e394f87 => 91
	i32 778756650, ; 37: SkiaSharp.HarfBuzz.dll => 0x2e6ae22a => 22
	i32 809851609, ; 38: System.Drawing.Common.dll => 0x30455ad9 => 3
	i32 843511501, ; 39: Xamarin.AndroidX.Print => 0x3246f6cd => 70
	i32 928116545, ; 40: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 87
	i32 955402788, ; 41: Newtonsoft.Json => 0x38f24a24 => 17
	i32 967690846, ; 42: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 60
	i32 974778368, ; 43: FormsViewGroup.dll => 0x3a19f000 => 7
	i32 1012816738, ; 44: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 72
	i32 1035644815, ; 45: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 42
	i32 1042160112, ; 46: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 84
	i32 1052210849, ; 47: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 64
	i32 1098259244, ; 48: System => 0x41761b2c => 27
	i32 1175144683, ; 49: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 76
	i32 1204270330, ; 50: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 43
	i32 1267360935, ; 51: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 77
	i32 1283425954, ; 52: LiveChartsCore.SkiaSharpView => 0x4c7f86a2 => 11
	i32 1293217323, ; 53: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 54
	i32 1357010908, ; 54: System.IO.Ports.dll => 0x50e257dc => 28
	i32 1365406463, ; 55: System.ServiceModel.Internals.dll => 0x516272ff => 95
	i32 1376866003, ; 56: Xamarin.AndroidX.SavedState => 0x52114ed3 => 72
	i32 1395857551, ; 57: Xamarin.AndroidX.Media.dll => 0x5333188f => 68
	i32 1406073936, ; 58: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 49
	i32 1411638395, ; 59: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 32
	i32 1460219004, ; 60: Xamarin.Forms.Xaml => 0x57092c7c => 85
	i32 1462112819, ; 61: System.IO.Compression.dll => 0x57261233 => 91
	i32 1469204771, ; 62: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 41
	i32 1582372066, ; 63: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 53
	i32 1592978981, ; 64: System.Runtime.Serialization.dll => 0x5ef2ee25 => 5
	i32 1622152042, ; 65: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 66
	i32 1624863272, ; 66: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 80
	i32 1632079564, ; 67: Microsoft.AspNet.SignalR.Client.dll => 0x61478ecc => 13
	i32 1636350590, ; 68: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 51
	i32 1639515021, ; 69: System.Net.Http.dll => 0x61b9038d => 4
	i32 1657153582, ; 70: System.Runtime => 0x62c6282e => 33
	i32 1658251792, ; 71: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 86
	i32 1722051300, ; 72: SkiaSharp.Views.Forms => 0x66a46ae4 => 24
	i32 1729485958, ; 73: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 47
	i32 1766324549, ; 74: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 74
	i32 1776026572, ; 75: System.Core.dll => 0x69dc03cc => 26
	i32 1788241197, ; 76: Xamarin.AndroidX.Fragment => 0x6a96652d => 55
	i32 1796167890, ; 77: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 14
	i32 1808609942, ; 78: Xamarin.AndroidX.Loader => 0x6bcd3296 => 66
	i32 1813201214, ; 79: Xamarin.Google.Android.Material => 0x6c13413e => 86
	i32 1849271627, ; 80: Prism.Forms.dll => 0x6e39a54b => 19
	i32 1867746548, ; 81: Xamarin.Essentials.dll => 0x6f538cf4 => 81
	i32 1878053835, ; 82: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 85
	i32 1885316902, ; 83: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 44
	i32 1919157823, ; 84: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 69
	i32 2011961780, ; 85: System.Buffers.dll => 0x77ec19b4 => 25
	i32 2019465201, ; 86: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 64
	i32 2055257422, ; 87: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 61
	i32 2066202781, ; 88: Prism => 0x7b27c09d => 18
	i32 2079903147, ; 89: System.Runtime.dll => 0x7bf8cdab => 33
	i32 2090596640, ; 90: System.Numerics.Vectors => 0x7c9bf920 => 31
	i32 2097448633, ; 91: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 57
	i32 2126786730, ; 92: Xamarin.Forms.Platform.Android => 0x7ec430aa => 83
	i32 2201231467, ; 93: System.Net.Http => 0x8334206b => 4
	i32 2217644978, ; 94: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 76
	i32 2240986525, ; 95: Microsoft.AspNet.SignalR.Client => 0x8592bd9d => 13
	i32 2244775296, ; 96: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 67
	i32 2256548716, ; 97: Xamarin.AndroidX.MultiDex => 0x8680336c => 69
	i32 2261435625, ; 98: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 59
	i32 2279755925, ; 99: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 71
	i32 2315684594, ; 100: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 39
	i32 2339410333, ; 101: AppSCADA.Android.dll => 0x8b70919d => 0
	i32 2471841756, ; 102: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 103: Java.Interop.dll => 0x93918882 => 9
	i32 2501346920, ; 104: System.Data.DataSetExtensions => 0x95178668 => 90
	i32 2505896520, ; 105: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 63
	i32 2570120770, ; 106: System.Text.Encodings.Web => 0x9930ee42 => 34
	i32 2581819634, ; 107: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 77
	i32 2620871830, ; 108: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 51
	i32 2633051222, ; 109: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 62
	i32 2689371776, ; 110: EasyModbus => 0xa04c8e80 => 2
	i32 2732626843, ; 111: Xamarin.AndroidX.Activity => 0xa2e0939b => 38
	i32 2737747696, ; 112: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 41
	i32 2766581644, ; 113: Xamarin.Forms.Core => 0xa4e6af8c => 82
	i32 2778768386, ; 114: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 79
	i32 2795602088, ; 115: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 23
	i32 2809969021, ; 116: S7.Net => 0xa77cb97d => 20
	i32 2810250172, ; 117: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 49
	i32 2819470561, ; 118: System.Xml.dll => 0xa80db4e1 => 36
	i32 2853208004, ; 119: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 79
	i32 2855708567, ; 120: Xamarin.AndroidX.Transition => 0xaa36a797 => 75
	i32 2903344695, ; 121: System.ComponentModel.Composition => 0xad0d8637 => 93
	i32 2905242038, ; 122: mscorlib.dll => 0xad2a79b6 => 16
	i32 2912489636, ; 123: SkiaSharp.Views.Android => 0xad9910a4 => 23
	i32 2916838712, ; 124: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 80
	i32 2919462931, ; 125: System.Numerics.Vectors.dll => 0xae037813 => 31
	i32 2921128767, ; 126: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 40
	i32 2974793899, ; 127: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 24
	i32 2978675010, ; 128: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 54
	i32 3024354802, ; 129: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 58
	i32 3044182254, ; 130: FormsViewGroup => 0xb57288ee => 7
	i32 3081706019, ; 131: LiveChartsCore => 0xb7af1a23 => 10
	i32 3111772706, ; 132: System.Runtime.Serialization => 0xb979e222 => 5
	i32 3124832203, ; 133: System.Threading.Tasks.Extensions => 0xba4127cb => 97
	i32 3152230736, ; 134: S7.Net.dll => 0xbbe33950 => 20
	i32 3204380047, ; 135: System.Data.dll => 0xbefef58f => 88
	i32 3211777861, ; 136: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 53
	i32 3247949154, ; 137: Mono.Security => 0xc197c562 => 96
	i32 3258312781, ; 138: Xamarin.AndroidX.CardView => 0xc235e84d => 47
	i32 3265893370, ; 139: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 97
	i32 3267021929, ; 140: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 45
	i32 3306135358, ; 141: System.IO.Ports => 0xc50f9f3e => 28
	i32 3317135071, ; 142: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 52
	i32 3317144872, ; 143: System.Data => 0xc5b79d28 => 88
	i32 3340387945, ; 144: SkiaSharp => 0xc71a4669 => 21
	i32 3340431453, ; 145: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 44
	i32 3353484488, ; 146: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 57
	i32 3357161156, ; 147: LiveChartsCore.SkiaSharpView.XamarinForms.dll => 0xc81a36c4 => 12
	i32 3358260929, ; 148: System.Text.Json => 0xc82afec1 => 35
	i32 3362522851, ; 149: Xamarin.AndroidX.Core => 0xc86c06e3 => 50
	i32 3366347497, ; 150: Java.Interop => 0xc8a662e9 => 9
	i32 3374999561, ; 151: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 71
	i32 3384551493, ; 152: LiveChartsCore.dll => 0xc9bc2845 => 10
	i32 3395150330, ; 153: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 32
	i32 3404865022, ; 154: System.ServiceModel.Internals => 0xcaf21dfe => 95
	i32 3429136800, ; 155: System.Xml => 0xcc6479a0 => 36
	i32 3430777524, ; 156: netstandard => 0xcc7d82b4 => 1
	i32 3461527568, ; 157: LiveChartsCore.SkiaSharpView.XamarinForms => 0xce52b810 => 12
	i32 3476120550, ; 158: Mono.Android => 0xcf3163e6 => 15
	i32 3485117614, ; 159: System.Text.Json.dll => 0xcfbaacae => 35
	i32 3486566296, ; 160: System.Transactions => 0xcfd0c798 => 89
	i32 3500225591, ; 161: AppSCADA => 0xd0a13437 => 6
	i32 3501239056, ; 162: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 45
	i32 3509114376, ; 163: System.Xml.Linq => 0xd128d608 => 37
	i32 3536029504, ; 164: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 83
	i32 3567349600, ; 165: System.ComponentModel.Composition.dll => 0xd4a16f60 => 93
	i32 3627220390, ; 166: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 70
	i32 3632359727, ; 167: Xamarin.Forms.Platform => 0xd881692f => 84
	i32 3633644679, ; 168: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 40
	i32 3641597786, ; 169: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 61
	i32 3672681054, ; 170: Mono.Android.dll => 0xdae8aa5e => 15
	i32 3676310014, ; 171: System.Web.Services.dll => 0xdb2009fe => 94
	i32 3682565725, ; 172: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 46
	i32 3689375977, ; 173: System.Drawing.Common => 0xdbe768e9 => 3
	i32 3718780102, ; 174: Xamarin.AndroidX.Annotation => 0xdda814c6 => 39
	i32 3758932259, ; 175: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 59
	i32 3786282454, ; 176: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 48
	i32 3792835768, ; 177: HarfBuzzSharp => 0xe21214b8 => 8
	i32 3815538226, ; 178: AppSCADA.dll => 0xe36c7e32 => 6
	i32 3822602673, ; 179: Xamarin.AndroidX.Media => 0xe3d849b1 => 68
	i32 3829621856, ; 180: System.Numerics.dll => 0xe4436460 => 30
	i32 3885922214, ; 181: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 75
	i32 3896760992, ; 182: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 50
	i32 3920810846, ; 183: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 92
	i32 3921031405, ; 184: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 78
	i32 3945713374, ; 185: System.Data.DataSetExtensions.dll => 0xeb2ecede => 90
	i32 3955647286, ; 186: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 42
	i32 4003906742, ; 187: HarfBuzzSharp.dll => 0xeea6c4b6 => 8
	i32 4025784931, ; 188: System.Memory => 0xeff49a63 => 29
	i32 4066802364, ; 189: SkiaSharp.HarfBuzz => 0xf2667abc => 22
	i32 4085261167, ; 190: Prism.Forms => 0xf380236f => 19
	i32 4105002889, ; 191: Mono.Security.dll => 0xf4ad5f89 => 96
	i32 4151237749, ; 192: System.Core => 0xf76edc75 => 26
	i32 4182413190, ; 193: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 65
	i32 4260525087, ; 194: System.Buffers => 0xfdf2741f => 25
	i32 4292120959 ; 195: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 65
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [196 x i32] [
	i32 11, i32 63, i32 87, i32 17, i32 82, i32 73, i32 73, i32 48, ; 0..7
	i32 74, i32 0, i32 46, i32 58, i32 94, i32 62, i32 56, i32 38, ; 8..15
	i32 30, i32 60, i32 29, i32 81, i32 55, i32 16, i32 27, i32 56, ; 16..23
	i32 67, i32 18, i32 21, i32 89, i32 14, i32 92, i32 2, i32 52, ; 24..31
	i32 34, i32 78, i32 43, i32 37, i32 91, i32 22, i32 3, i32 70, ; 32..39
	i32 87, i32 17, i32 60, i32 7, i32 72, i32 42, i32 84, i32 64, ; 40..47
	i32 27, i32 76, i32 43, i32 77, i32 11, i32 54, i32 28, i32 95, ; 48..55
	i32 72, i32 68, i32 49, i32 32, i32 85, i32 91, i32 41, i32 53, ; 56..63
	i32 5, i32 66, i32 80, i32 13, i32 51, i32 4, i32 33, i32 86, ; 64..71
	i32 24, i32 47, i32 74, i32 26, i32 55, i32 14, i32 66, i32 86, ; 72..79
	i32 19, i32 81, i32 85, i32 44, i32 69, i32 25, i32 64, i32 61, ; 80..87
	i32 18, i32 33, i32 31, i32 57, i32 83, i32 4, i32 76, i32 13, ; 88..95
	i32 67, i32 69, i32 59, i32 71, i32 39, i32 0, i32 1, i32 9, ; 96..103
	i32 90, i32 63, i32 34, i32 77, i32 51, i32 62, i32 2, i32 38, ; 104..111
	i32 41, i32 82, i32 79, i32 23, i32 20, i32 49, i32 36, i32 79, ; 112..119
	i32 75, i32 93, i32 16, i32 23, i32 80, i32 31, i32 40, i32 24, ; 120..127
	i32 54, i32 58, i32 7, i32 10, i32 5, i32 97, i32 20, i32 88, ; 128..135
	i32 53, i32 96, i32 47, i32 97, i32 45, i32 28, i32 52, i32 88, ; 136..143
	i32 21, i32 44, i32 57, i32 12, i32 35, i32 50, i32 9, i32 71, ; 144..151
	i32 10, i32 32, i32 95, i32 36, i32 1, i32 12, i32 15, i32 35, ; 152..159
	i32 89, i32 6, i32 45, i32 37, i32 83, i32 93, i32 70, i32 84, ; 160..167
	i32 40, i32 61, i32 15, i32 94, i32 46, i32 3, i32 39, i32 59, ; 168..175
	i32 48, i32 8, i32 6, i32 68, i32 30, i32 75, i32 50, i32 92, ; 176..183
	i32 78, i32 90, i32 42, i32 8, i32 29, i32 22, i32 19, i32 96, ; 184..191
	i32 26, i32 65, i32 25, i32 65 ; 192..195
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
