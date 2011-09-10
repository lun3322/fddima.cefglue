describe("ScriptableObject", function () {
    var so;

    beforeEach(function () {
        // TODO: must be cefGlue.scriptableObject.tests.jsBinding
        so = testScriptableObject;
    });

    describe("echoVoid", function () {
        var func;

        beforeEach(function () {
            func = so.echoVoid;
        });

        it("should return undefined", function () {
            expect(
                func()
            ).toBeUndefined();
        });

        it("should throw an exception if arguments count mismatch", function () {
            expect(function () {
                func(undefined);
            }).toThrow();
        });
    });

    describe("echoBoolean", function () {
        var func;

        beforeEach(function () {
            func = so.echoBoolean;
        });

        it("(+) V8.Boolean -> System.Boolean", function () {
            expect(func(true)).toEqual(true);
            expect(func(false)).toEqual(false);
            expect(typeof func(true)).toEqual("boolean");
        });

        it("(-) V8.Undefined -> System.Boolean", function () {
            expect(function () {
                func(undefined);
            }).toThrow();
        });

        it("should throw an exception if argument is null", function () {
            expect(function () {
                func(null);
            }).toThrow();
        });

        it("should throw an exception if argument is number (V8 int32)", function () {
            expect(function () {
                func(1);
            }).toThrow();
            expect(function () {
                func(1.123);
            }).toThrow();
        });

        it("should throw an exception if argument is number (V8 double)", function () {
            expect(function () {
                func(1.123);
            }).toThrow();
        });

        it("should throw an exception if argument is string", function () {
            expect(function () {
                func("123");
            }).toThrow();
        });

        it("should throw an exception if argument is Date", function () {
            expect(function () {
                func(new Date());
            }).toThrow();
        });

        it("should throw an exception if argument is Array", function () {
            expect(function () {
                func([]);
            }).toThrow();
        });

        it("should throw an exception if argument is Object", function () {
            expect(function () {
                func({});
            }).toThrow();
        });

        it("should throw an exception if argument is function", function () {
            expect(function () {
                func(function () { });
            }).toThrow();
        });

        it("should throw an exception if arguments count mismatch", function () {
            expect(function () {
                func();
            }).toThrow();
            expect(function () {
                func(true, undefined);
            }).toThrow();
        });
    });

    describe("echoInt32", function () {
        var func;

        beforeEach(function () {
            func = so.echoInt32;
        });

        it("should throw an exception if argument is undefined", function () {
            expect(function () {
                func(undefined);
            }).toThrow();
        });

        it("should throw an exception if argument is null", function () {
            expect(function () {
                func(null);
            }).toThrow();
        });

        it("should throw an exception if argument is boolean", function () {
            expect(function () {
                func(true);
            }).toThrow();
        });

        it("should return argument value if argument is number (V8 int32)", function () {
            expect(func(0)).toEqual(0);

            expect(func(+0x11223344)).toEqual(+0x11223344);
            expect(func(-0x11223344)).toEqual(-0x11223344);

            expect(func(+0x7FFFFFFF)).toEqual(+0x7FFFFFFF);
            expect(func(-0x80000000)).toEqual(-0x80000000);
        });

        it("should throw an exception if argument is number, but it is in out of range", function () {
            expect(function () {
                func(+0x80000000);
            }).toThrow();
            expect(function () {
                func(-0x80000001);
            }).toThrow();
        });

        it("should throw an exception if argument is number (double)", function () {
            expect(function () {
                func(1.123);
            }).toThrow();
        });

        it("should throw an exception if argument is string", function () {
            expect(function () {
                func("123");
            }).toThrow();
        });

        it("should throw an exception if argument is date", function () {
            expect(function () {
                func(new Date());
            }).toThrow();
        });

        it("should throw an exception if argument is array", function () {
            expect(function () {
                func([]);
            }).toThrow();
        });

        it("should throw an exception if argument is object", function () {
            expect(function () {
                func({});
            }).toThrow();
        });

        it("should throw an exception if argument is function", function () {
            expect(function () {
                func(function () { });
            }).toThrow();
        });

        it("should throw an exception if arguments count mismatch", function () {
            expect(function () {
                func();
            }).toThrow();
            expect(function () {
                func(true, undefined);
            }).toThrow();
        });
    });

    describe("echoDouble", function () {
        var func;

        beforeEach(function () {
            func = so.echoDouble;
        });

        it("should throw an exception if argument is undefined", function () {
            expect(function () {
                func(undefined);
            }).toThrow();
        });

        it("should throw an exception if argument is null", function () {
            expect(function () {
                func(null);
            }).toThrow();
        });

        it("should throw an exception if argument is boolean", function () {
            expect(function () {
                func(true);
            }).toThrow();
        });

        it("should return argument value if argument is number (V8 int32)", function () {
            expect(func(0)).toEqual(0);

            expect(func(+0x11223344)).toEqual(+0x11223344);
            expect(func(-0x11223344)).toEqual(-0x11223344);

            expect(func(+0x7FFFFFFF)).toEqual(+0x7FFFFFFF);
            expect(func(-0x80000000)).toEqual(-0x80000000);
        });

        it("should return argument value if argument is number (V8 int32)", function () {
            expect(func(1.123)).toEqual(1.123);
            expect(func(-2.1234567)).toEqual(-2.1234567);
            expect(isNaN(func(NaN))).toBeTruthy();
        });

        it("should throw an exception if argument is string", function () {
            expect(function () {
                func("123");
            }).toThrow();
        });

        it("should throw an exception if argument is date", function () {
            expect(function () {
                func(new Date());
            }).toThrow();
        });

        it("should throw an exception if argument is array", function () {
            expect(function () {
                func([]);
            }).toThrow();
        });

        it("should throw an exception if argument is object", function () {
            expect(function () {
                func({});
            }).toThrow();
        });

        it("should throw an exception if argument is function", function () {
            expect(function () {
                func(function () { });
            }).toThrow();
        });

        it("should throw an exception if arguments count mismatch", function () {
            expect(function () {
                func();
            }).toThrow();
            expect(function () {
                func(true, undefined);
            }).toThrow();
        });
    });

    describe("echoString", function () {
        var func;

        beforeEach(function () {
            func = so.echoString;
        });

        it("(+) V8.Undefined -> System.String : V8.Null", function () {
            expect(func(undefined)).toBeNull();
        });

        it("(+) V8.Null -> System.String : V8.Null", function () {
            expect(func(null)).toBeNull();
        });

        it("should throw an exception if argument is boolean", function () {
            expect(function () {
                func(true);
            }).toThrow();
        });

        it("(-) V8.Int32 -> System.String", function () {
            expect(function () {
                func(0)
            }).toThrow();
        });

        it("should throw an exception if argument is number (double)", function () {
            expect(function () {
                func(1.123);
            }).toThrow();
        });

        it("(+) V8.String -> System.String -> V8.String", function () {
            expect(func("hello, world!")).toEqual("hello, world!");
        });

        it("(+) V8.String(Empty) -> System.String -> V8.Null", function () {
            expect(func("")).toBeNull();
        });

        it("should throw an exception if argument is date", function () {
            expect(function () {
                func(new Date());
            }).toThrow();
        });

        it("should throw an exception if argument is array", function () {
            expect(function () {
                func([]);
            }).toThrow();
        });

        it("should throw an exception if argument is object", function () {
            expect(function () {
                func({});
            }).toThrow();
        });

        it("should throw an exception if argument is function", function () {
            expect(function () {
                func(function () { });
            }).toThrow();
        });

        it("should throw an exception if arguments count mismatch", function () {
            expect(function () {
                func();
            }).toThrow();
            expect(function () {
                func(true, undefined);
            }).toThrow();
        });
    });

});