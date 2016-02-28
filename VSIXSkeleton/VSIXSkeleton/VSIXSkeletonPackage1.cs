namespace VSIXSkeleton
{
    using System;
    
    /// <summary>
    /// Helper class that exposes all GUIDs used across VS Package.
    /// </summary>
    internal sealed partial class PackageGuids
    {
        public const string guidVSIXSkeletonPackageString = "dbc16a1d-e139-405d-b170-457d0725eccb";
        public const string guidVSIXSkeletonPackageCmdSetString = "7089dc23-da22-4247-a401-13d348420447";
        public const string guidImagesString = "ebd99c81-db0a-43cb-a727-91ecfab7065d";
        public static Guid guidVSIXSkeletonPackage = new Guid(guidVSIXSkeletonPackageString);
        public static Guid guidVSIXSkeletonPackageCmdSet = new Guid(guidVSIXSkeletonPackageCmdSetString);
        public static Guid guidImages = new Guid(guidImagesString);
    }
    /// <summary>
    /// Helper class that encapsulates all CommandIDs uses across VS Package.
    /// </summary>
    internal sealed partial class PackageIds
    {
        public const int MyMenu = 0x1000;
        public const int MySubMenuGroup = 0x2000;
        public const int Command1Id = 0x0100;
        public const int bmpPic1 = 0x0001;
        public const int bmpPic2 = 0x0002;
        public const int bmpPicSearch = 0x0003;
        public const int bmpPicX = 0x0004;
        public const int bmpPicArrows = 0x0005;
        public const int bmpPicStrikethrough = 0x0006;
    }
}
