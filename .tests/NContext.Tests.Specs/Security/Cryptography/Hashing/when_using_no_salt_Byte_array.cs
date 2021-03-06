﻿namespace NContext.Tests.Specs.Security.Cryptography
{
    using System;
    using System.Text;

    using Machine.Specifications;

    using NContext.Extensions;

    public class when_using_no_salt_Byte_array : when_hashing_with_HashProvider
    {
        Because of = () => _SourceHash = HashProvider.CreateHash("NContext".ToBytes<UnicodeEncoding>(), 0);

        It should_be_of_fixed_length = () => _SourceHash.Length.ShouldEqual(20);
        It should_equal_the_target_Byte_array = () => HashProvider.CompareHash("NContext".ToBytes<UnicodeEncoding>(), _SourceHash, 0).ShouldEqual(true);
        
        private static Byte[] _SourceHash;
    }
}