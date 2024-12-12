; ModuleID = 'obj\Debug\110\android\marshal_methods.armeabi-v7a.ll'
source_filename = "obj\Debug\110\android\marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


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
@assembly_image_cache_hashes = local_unnamed_addr constant [194 x i32] [
	i32 10266594, ; 0: LiveChartsCore.SkiaSharpView.dll => 0x9ca7e2 => 10
	i32 32687329, ; 1: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 62
	i32 34715100, ; 2: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 86
	i32 39109920, ; 3: Newtonsoft.Json.dll => 0x254c520 => 16
	i32 57263871, ; 4: Xamarin.Forms.Core.dll => 0x369c6ff => 81
	i32 101534019, ; 5: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 72
	i32 120558881, ; 6: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 72
	i32 165246403, ; 7: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 47
	i32 182336117, ; 8: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 73
	i32 205525720, ; 9: AppSCADA.Android => 0xc4012d8 => 0
	i32 209399409, ; 10: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 45
	i32 230216969, ; 11: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 57
	i32 232815796, ; 12: System.Web.Services => 0xde07cb4 => 93
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 61
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 55
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 37
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 29
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 59
	i32 385762202, ; 18: System.Memory.dll => 0x16fe439a => 28
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 80
	i32 450948140, ; 20: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 54
	i32 465846621, ; 21: mscorlib => 0x1bc4415d => 15
	i32 469710990, ; 22: System.dll => 0x1bff388e => 26
	i32 476646585, ; 23: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 55
	i32 486930444, ; 24: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 66
	i32 501000162, ; 25: Prism.dll => 0x1ddca7e2 => 17
	i32 525008092, ; 26: SkiaSharp.dll => 0x1f4afcdc => 20
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 88
	i32 548916678, ; 28: Microsoft.Bcl.AsyncInterfaces => 0x20b7cdc6 => 13
	i32 605376203, ; 29: System.IO.Compression.FileSystem => 0x24154ecb => 91
	i32 627609679, ; 30: Xamarin.AndroidX.CustomView => 0x2568904f => 51
	i32 662205335, ; 31: System.Text.Encodings.Web.dll => 0x27787397 => 33
	i32 663517072, ; 32: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 77
	i32 666292255, ; 33: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 42
	i32 690569205, ; 34: System.Xml.Linq.dll => 0x29293ff5 => 36
	i32 775507847, ; 35: System.IO.Compression => 0x2e394f87 => 90
	i32 778756650, ; 36: SkiaSharp.HarfBuzz.dll => 0x2e6ae22a => 21
	i32 809851609, ; 37: System.Drawing.Common.dll => 0x30455ad9 => 2
	i32 843511501, ; 38: Xamarin.AndroidX.Print => 0x3246f6cd => 69
	i32 928116545, ; 39: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 86
	i32 955402788, ; 40: Newtonsoft.Json => 0x38f24a24 => 16
	i32 967690846, ; 41: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 59
	i32 974778368, ; 42: FormsViewGroup.dll => 0x3a19f000 => 6
	i32 1012816738, ; 43: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 71
	i32 1035644815, ; 44: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 41
	i32 1042160112, ; 45: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 83
	i32 1052210849, ; 46: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 63
	i32 1098259244, ; 47: System => 0x41761b2c => 26
	i32 1175144683, ; 48: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 75
	i32 1204270330, ; 49: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 42
	i32 1267360935, ; 50: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 76
	i32 1283425954, ; 51: LiveChartsCore.SkiaSharpView => 0x4c7f86a2 => 10
	i32 1293217323, ; 52: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 53
	i32 1357010908, ; 53: System.IO.Ports.dll => 0x50e257dc => 27
	i32 1365406463, ; 54: System.ServiceModel.Internals.dll => 0x516272ff => 94
	i32 1376866003, ; 55: Xamarin.AndroidX.SavedState => 0x52114ed3 => 71
	i32 1395857551, ; 56: Xamarin.AndroidX.Media.dll => 0x5333188f => 67
	i32 1406073936, ; 57: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 48
	i32 1411638395, ; 58: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 31
	i32 1460219004, ; 59: Xamarin.Forms.Xaml => 0x57092c7c => 84
	i32 1462112819, ; 60: System.IO.Compression.dll => 0x57261233 => 90
	i32 1469204771, ; 61: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 40
	i32 1582372066, ; 62: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 52
	i32 1592978981, ; 63: System.Runtime.Serialization.dll => 0x5ef2ee25 => 4
	i32 1622152042, ; 64: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 65
	i32 1624863272, ; 65: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 79
	i32 1632079564, ; 66: Microsoft.AspNet.SignalR.Client.dll => 0x61478ecc => 12
	i32 1636350590, ; 67: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 50
	i32 1639515021, ; 68: System.Net.Http.dll => 0x61b9038d => 3
	i32 1657153582, ; 69: System.Runtime => 0x62c6282e => 32
	i32 1658251792, ; 70: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 85
	i32 1722051300, ; 71: SkiaSharp.Views.Forms => 0x66a46ae4 => 23
	i32 1729485958, ; 72: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 46
	i32 1766324549, ; 73: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 73
	i32 1776026572, ; 74: System.Core.dll => 0x69dc03cc => 25
	i32 1788241197, ; 75: Xamarin.AndroidX.Fragment => 0x6a96652d => 54
	i32 1796167890, ; 76: Microsoft.Bcl.AsyncInterfaces.dll => 0x6b0f58d2 => 13
	i32 1808609942, ; 77: Xamarin.AndroidX.Loader => 0x6bcd3296 => 65
	i32 1813201214, ; 78: Xamarin.Google.Android.Material => 0x6c13413e => 85
	i32 1849271627, ; 79: Prism.Forms.dll => 0x6e39a54b => 18
	i32 1867746548, ; 80: Xamarin.Essentials.dll => 0x6f538cf4 => 80
	i32 1878053835, ; 81: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 84
	i32 1885316902, ; 82: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 43
	i32 1919157823, ; 83: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 68
	i32 2011961780, ; 84: System.Buffers.dll => 0x77ec19b4 => 24
	i32 2019465201, ; 85: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 63
	i32 2055257422, ; 86: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 60
	i32 2066202781, ; 87: Prism => 0x7b27c09d => 17
	i32 2079903147, ; 88: System.Runtime.dll => 0x7bf8cdab => 32
	i32 2090596640, ; 89: System.Numerics.Vectors => 0x7c9bf920 => 30
	i32 2097448633, ; 90: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 56
	i32 2126786730, ; 91: Xamarin.Forms.Platform.Android => 0x7ec430aa => 82
	i32 2201231467, ; 92: System.Net.Http => 0x8334206b => 3
	i32 2217644978, ; 93: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 75
	i32 2240986525, ; 94: Microsoft.AspNet.SignalR.Client => 0x8592bd9d => 12
	i32 2244775296, ; 95: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 66
	i32 2256548716, ; 96: Xamarin.AndroidX.MultiDex => 0x8680336c => 68
	i32 2261435625, ; 97: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 58
	i32 2279755925, ; 98: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 70
	i32 2315684594, ; 99: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 38
	i32 2339410333, ; 100: AppSCADA.Android.dll => 0x8b70919d => 0
	i32 2471841756, ; 101: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 102: Java.Interop.dll => 0x93918882 => 8
	i32 2501346920, ; 103: System.Data.DataSetExtensions => 0x95178668 => 89
	i32 2505896520, ; 104: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 62
	i32 2570120770, ; 105: System.Text.Encodings.Web => 0x9930ee42 => 33
	i32 2581819634, ; 106: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 76
	i32 2620871830, ; 107: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 50
	i32 2633051222, ; 108: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 61
	i32 2732626843, ; 109: Xamarin.AndroidX.Activity => 0xa2e0939b => 37
	i32 2737747696, ; 110: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 40
	i32 2766581644, ; 111: Xamarin.Forms.Core => 0xa4e6af8c => 81
	i32 2778768386, ; 112: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 78
	i32 2795602088, ; 113: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 22
	i32 2809969021, ; 114: S7.Net => 0xa77cb97d => 19
	i32 2810250172, ; 115: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 48
	i32 2819470561, ; 116: System.Xml.dll => 0xa80db4e1 => 35
	i32 2853208004, ; 117: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 78
	i32 2855708567, ; 118: Xamarin.AndroidX.Transition => 0xaa36a797 => 74
	i32 2903344695, ; 119: System.ComponentModel.Composition => 0xad0d8637 => 92
	i32 2905242038, ; 120: mscorlib.dll => 0xad2a79b6 => 15
	i32 2912489636, ; 121: SkiaSharp.Views.Android => 0xad9910a4 => 22
	i32 2916838712, ; 122: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 79
	i32 2919462931, ; 123: System.Numerics.Vectors.dll => 0xae037813 => 30
	i32 2921128767, ; 124: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 39
	i32 2974793899, ; 125: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 23
	i32 2978675010, ; 126: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 53
	i32 3024354802, ; 127: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 57
	i32 3044182254, ; 128: FormsViewGroup => 0xb57288ee => 6
	i32 3081706019, ; 129: LiveChartsCore => 0xb7af1a23 => 9
	i32 3111772706, ; 130: System.Runtime.Serialization => 0xb979e222 => 4
	i32 3124832203, ; 131: System.Threading.Tasks.Extensions => 0xba4127cb => 96
	i32 3152230736, ; 132: S7.Net.dll => 0xbbe33950 => 19
	i32 3204380047, ; 133: System.Data.dll => 0xbefef58f => 87
	i32 3211777861, ; 134: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 52
	i32 3247949154, ; 135: Mono.Security => 0xc197c562 => 95
	i32 3258312781, ; 136: Xamarin.AndroidX.CardView => 0xc235e84d => 46
	i32 3265893370, ; 137: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 96
	i32 3267021929, ; 138: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 44
	i32 3306135358, ; 139: System.IO.Ports => 0xc50f9f3e => 27
	i32 3317135071, ; 140: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 51
	i32 3317144872, ; 141: System.Data => 0xc5b79d28 => 87
	i32 3340387945, ; 142: SkiaSharp => 0xc71a4669 => 20
	i32 3340431453, ; 143: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 43
	i32 3353484488, ; 144: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 56
	i32 3357161156, ; 145: LiveChartsCore.SkiaSharpView.XamarinForms.dll => 0xc81a36c4 => 11
	i32 3358260929, ; 146: System.Text.Json => 0xc82afec1 => 34
	i32 3362522851, ; 147: Xamarin.AndroidX.Core => 0xc86c06e3 => 49
	i32 3366347497, ; 148: Java.Interop => 0xc8a662e9 => 8
	i32 3374999561, ; 149: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 70
	i32 3384551493, ; 150: LiveChartsCore.dll => 0xc9bc2845 => 9
	i32 3395150330, ; 151: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 31
	i32 3404865022, ; 152: System.ServiceModel.Internals => 0xcaf21dfe => 94
	i32 3429136800, ; 153: System.Xml => 0xcc6479a0 => 35
	i32 3430777524, ; 154: netstandard => 0xcc7d82b4 => 1
	i32 3461527568, ; 155: LiveChartsCore.SkiaSharpView.XamarinForms => 0xce52b810 => 11
	i32 3476120550, ; 156: Mono.Android => 0xcf3163e6 => 14
	i32 3485117614, ; 157: System.Text.Json.dll => 0xcfbaacae => 34
	i32 3486566296, ; 158: System.Transactions => 0xcfd0c798 => 88
	i32 3500225591, ; 159: AppSCADA => 0xd0a13437 => 5
	i32 3501239056, ; 160: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 44
	i32 3509114376, ; 161: System.Xml.Linq => 0xd128d608 => 36
	i32 3536029504, ; 162: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 82
	i32 3567349600, ; 163: System.ComponentModel.Composition.dll => 0xd4a16f60 => 92
	i32 3627220390, ; 164: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 69
	i32 3632359727, ; 165: Xamarin.Forms.Platform => 0xd881692f => 83
	i32 3633644679, ; 166: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 39
	i32 3641597786, ; 167: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 60
	i32 3672681054, ; 168: Mono.Android.dll => 0xdae8aa5e => 14
	i32 3676310014, ; 169: System.Web.Services.dll => 0xdb2009fe => 93
	i32 3682565725, ; 170: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 45
	i32 3689375977, ; 171: System.Drawing.Common => 0xdbe768e9 => 2
	i32 3718780102, ; 172: Xamarin.AndroidX.Annotation => 0xdda814c6 => 38
	i32 3758932259, ; 173: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 58
	i32 3786282454, ; 174: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 47
	i32 3792835768, ; 175: HarfBuzzSharp => 0xe21214b8 => 7
	i32 3815538226, ; 176: AppSCADA.dll => 0xe36c7e32 => 5
	i32 3822602673, ; 177: Xamarin.AndroidX.Media => 0xe3d849b1 => 67
	i32 3829621856, ; 178: System.Numerics.dll => 0xe4436460 => 29
	i32 3885922214, ; 179: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 74
	i32 3896760992, ; 180: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 49
	i32 3920810846, ; 181: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 91
	i32 3921031405, ; 182: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 77
	i32 3945713374, ; 183: System.Data.DataSetExtensions.dll => 0xeb2ecede => 89
	i32 3955647286, ; 184: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 41
	i32 4003906742, ; 185: HarfBuzzSharp.dll => 0xeea6c4b6 => 7
	i32 4025784931, ; 186: System.Memory => 0xeff49a63 => 28
	i32 4066802364, ; 187: SkiaSharp.HarfBuzz => 0xf2667abc => 21
	i32 4085261167, ; 188: Prism.Forms => 0xf380236f => 18
	i32 4105002889, ; 189: Mono.Security.dll => 0xf4ad5f89 => 95
	i32 4151237749, ; 190: System.Core => 0xf76edc75 => 25
	i32 4182413190, ; 191: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 64
	i32 4260525087, ; 192: System.Buffers => 0xfdf2741f => 24
	i32 4292120959 ; 193: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 64
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [194 x i32] [
	i32 10, i32 62, i32 86, i32 16, i32 81, i32 72, i32 72, i32 47, ; 0..7
	i32 73, i32 0, i32 45, i32 57, i32 93, i32 61, i32 55, i32 37, ; 8..15
	i32 29, i32 59, i32 28, i32 80, i32 54, i32 15, i32 26, i32 55, ; 16..23
	i32 66, i32 17, i32 20, i32 88, i32 13, i32 91, i32 51, i32 33, ; 24..31
	i32 77, i32 42, i32 36, i32 90, i32 21, i32 2, i32 69, i32 86, ; 32..39
	i32 16, i32 59, i32 6, i32 71, i32 41, i32 83, i32 63, i32 26, ; 40..47
	i32 75, i32 42, i32 76, i32 10, i32 53, i32 27, i32 94, i32 71, ; 48..55
	i32 67, i32 48, i32 31, i32 84, i32 90, i32 40, i32 52, i32 4, ; 56..63
	i32 65, i32 79, i32 12, i32 50, i32 3, i32 32, i32 85, i32 23, ; 64..71
	i32 46, i32 73, i32 25, i32 54, i32 13, i32 65, i32 85, i32 18, ; 72..79
	i32 80, i32 84, i32 43, i32 68, i32 24, i32 63, i32 60, i32 17, ; 80..87
	i32 32, i32 30, i32 56, i32 82, i32 3, i32 75, i32 12, i32 66, ; 88..95
	i32 68, i32 58, i32 70, i32 38, i32 0, i32 1, i32 8, i32 89, ; 96..103
	i32 62, i32 33, i32 76, i32 50, i32 61, i32 37, i32 40, i32 81, ; 104..111
	i32 78, i32 22, i32 19, i32 48, i32 35, i32 78, i32 74, i32 92, ; 112..119
	i32 15, i32 22, i32 79, i32 30, i32 39, i32 23, i32 53, i32 57, ; 120..127
	i32 6, i32 9, i32 4, i32 96, i32 19, i32 87, i32 52, i32 95, ; 128..135
	i32 46, i32 96, i32 44, i32 27, i32 51, i32 87, i32 20, i32 43, ; 136..143
	i32 56, i32 11, i32 34, i32 49, i32 8, i32 70, i32 9, i32 31, ; 144..151
	i32 94, i32 35, i32 1, i32 11, i32 14, i32 34, i32 88, i32 5, ; 152..159
	i32 44, i32 36, i32 82, i32 92, i32 69, i32 83, i32 39, i32 60, ; 160..167
	i32 14, i32 93, i32 45, i32 2, i32 38, i32 58, i32 47, i32 7, ; 168..175
	i32 5, i32 67, i32 29, i32 74, i32 49, i32 91, i32 77, i32 89, ; 176..183
	i32 41, i32 7, i32 28, i32 21, i32 18, i32 95, i32 25, i32 64, ; 184..191
	i32 24, i32 64 ; 192..193
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
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


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
