describe("ScriptableObject", function () {
    var so;

    beforeEach(function () {
        // TODO: must be cefGlue.scriptableObject.tests.jsBinding
        so = testScriptableObject;
    });

    function describeEcho(name, data) {
        describe(name, function () {
            if (data.expect) {
                data.expect.forEach(function (value) {
                    it("(+) " + (value ? value.toString() : value), function () {
                        expect(so[name](value)).toEqual(value);
                    });
                });
            }
            if (data.expectNull) {
                data.expectNull.forEach(function (value) {
                    it("(+) " + (value ? value.toString() : value), function () {
                        expect(so[name](value)).toBeNull();
                    });
                });
            }
            if (data.expectNaN) {
                data.expectNaN.forEach(function (value) {
                    it("(+) " + (value ? value.toString() : value), function () {
                        expect(isNaN(so[name](value))).toBeTruthy();
                    });
                });
            }
            if (data.expectFloat) {
                data.expectFloat.forEach(function (value) {
                    it("(+) " + (value ? value.toString() : value), function () {
                        expect( so[name](value).toFixed(4) ).toEqual(value.toFixed(4));
                    });
                });
            }
            if (data.expectMap) {
                data.expectMap.forEach(function (value) {
                    it("(+) " + (value[0] ? value[0].toString() : value[0]) + " -> " + (value[1] ? value[1].toString() : value[1]), function () {
                        expect(so[name](value[0])).toEqual(value[1]);
                    });
                });
            }
            if (data.throws) {
                data.throws.forEach(function (value) {
                    it("(-) " + (value ? value.toString() : value), function () {
                        expect(function () { so[name](value) }).toThrow();
                    });
                });
            }
        });
    }

    describe("echoVoid", function () {
        var func;

        beforeEach(function () {
            func = so.echoVoid;
        });

        it("(+) System.Void -> V8.Undefined", function () {
            expect(
                func()
            ).toBeUndefined();
        });
    });

    describeEcho("echoBoolean", {
        expect: [true, false],
        throws: [undefined, null, 1, 1.123, "hello!", new Date(), [], {}, function () { } ]
    });

    describeEcho("echoInt32", {
        expect: [0, -0x80000000, +0x7FFFFFFF],
        throws: [
            -0x80000001, +0x80000000,
            undefined, null, true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoDouble", {
        expect: [0, -0x80000000, +0x7FFFFFFF, 1.123],
        expectNaN: [NaN],
        throws: [undefined, null, true, "hello!", new Date(), [], {}, function () { } ]
    });

    describeEcho("echoString", {
        expect: ["hello!"],
        expectNull: [undefined, null, ""],
        throws: [true, 1, 1.123, new Date(), [], {}, function () { } ]
    });

    describeEcho("echoDateTime", {
        expect: [new Date()],
        expectNull: [],
        throws: [undefined, null, true, 1, 1.123, "hello!", [], {}, function () { } ]
    });

    describeEcho("echoByte", {
        expect: [0, 255],
        throws: [
            -1, 256,
            undefined, null, true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoSByte", {
        expect: [0, -128, 127],
        throws: [
            -129, 257,
            undefined, null, true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoInt16", {
        expect: [0, -32768, 32767],
        throws: [
            -32769, 32768,
            undefined, null, true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoUInt16", {
        expect: [0, 65535],
        throws: [
            -1, 65536,
            undefined, null, true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoChar", {
        expect: [0, 65535],
        expectMap: [
            ["a", ("a".charCodeAt(0))]
        ],
        throws: [
            -1, 65536,
            undefined, null, true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoSingle", {
        expectFloat: [0, -0x800000, +0x7FFFFF, 1.123],
        throws: [undefined, null, true, "hello!", new Date(), [], {}, function () { } ]
    });

    describeEcho("echoNullableBoolean", {
        expect: [true, false],
        expectNull: [undefined, null],
        throws: [1, 1.123, "hello!", new Date(), [], {}, function () { } ]
    });

    describeEcho("echoNullableInt32", {
        expect: [0, -0x80000000, +0x7FFFFFFF],
        expectNull: [undefined, null],
        throws: [
            -0x80000001, +0x80000000,
            true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoNullableDouble", {
        expect: [0, -0x80000000, +0x7FFFFFFF, 1.123],
        expectNaN: [NaN],
        expectNull: [undefined, null],
        throws: [true, "hello!", new Date(), [], {}, function () { } ]
    });

    describeEcho("echoNullableDateTime", {
        expect: [new Date()],
        expectNull: [undefined, null],
        throws: [true, 1, 1.123, "hello!", [], {}, function () { } ]
    });

    describeEcho("echoNullableByte", {
        expect: [0, 255],
        expectNull: [undefined, null],
        throws: [
            -1, 256,
            true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoNullableSByte", {
        expect: [0, -128, 127],
        expectNull: [undefined, null],
        throws: [
            -129, 257,
            true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoNullableInt16", {
        expect: [0, -32768, 32767],
        expectNull: [undefined, null],
        throws: [
            -32769, 32768,
            true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoNullableUInt16", {
        expect: [0, 65535],
        expectNull: [undefined, null],
        throws: [
            -1, 65536,
            true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoNullableChar", {
        expect: [0, 65535],
        expectMap: [
            ["a", ("a".charCodeAt(0))]
        ],
        expectNull: [undefined, null],
        throws: [
            -1, 65536,
            true, 1.123, "hello!", new Date(), [], {}, function () { }
            ]
    });

    describeEcho("echoNullableSingle", {
        expectFloat: [0, -0x800000, +0x7FFFFF, 1.123],
        expectNull: [undefined, null],
        throws: [true, "hello!", new Date(), [], {}, function () { } ]
    });

    describe("argument count mismatch", function () {
        it("should throw an exception if arguments count mismatch", function () {
            expect(function () {
                so.argumentCount0(1);
            }).toThrow();

            expect(function () {
                so.argumentCount1();
            }).toThrow();

            expect(function () {
                so.argumentCount1(1, 2);
            }).toThrow();

            expect(function () {
                so.argumentCount2(1, 2, undefined);
            }).toThrow();
        });
    });

});