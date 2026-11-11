<div dir="rtl">

# 💻 السي شارب المتقدم — المحاضرة 02: المفوضات (Delegates)، تعبيرات Lambda، ونظام ShopMaster
### Advanced C# 02: Delegates, Func/Action/Predicate, Lambdas & ShopMaster Order Engine

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![Module](https://img.shields.io/badge/Module-03_Advanced_CSharp-0284c7?style=for-the-badge)](#)
[![Interactive Guide](https://img.shields.io/badge/%F0%9F%8C%90_Live_Study_Guide-HTML_Interactive-8b5cf6?style=for-the-badge)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-02/blob/master/Study_Guide/Delegates_Part1_Core.html)

> **نبذة عن المشروع:** ⚡ [03 Advanced C# - Session 02] ShopMaster Online Store Engine: Custom & Built-in Delegates (Func, Action, Predicate), Multicast Delegates, Lambda Expressions & Closures + 3 HTML Guides.

---

## 🌐 الدليل التفاعلي المشروح بالـ HTML (Interactive Study Guide)

تم تضمين الدليل التفاعلي المشروح بالكامل داخل مجلد [`Study_Guide/`](./Study_Guide) في هذا المستودع، ويمكنك قراءته مباشرة في المتصفح عبر الروابط التالية:

- 🌐 الدليل التفاعلي (1/3): تشريح الـ Delegate والـ Multicast في الذاكرة (HTML): **[🌐 معاينة حية في المتصفح (Live Preview)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-02/blob/master/Study_Guide/Delegates_Part1_Core.html)** | **[📄 فتح ملف الـ HTML في المستودع](./Study_Guide/Delegates_Part1_Core.html)**
- 🌐 الدليل التفاعلي (2/3): Func / Action / Predicate والـ Lambdas والـ Closures (HTML): **[🌐 معاينة حية في المتصفح (Live Preview)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-02/blob/master/Study_Guide/Delegates_Part2_Lambda_Closures.html)** | **[📄 فتح ملف الـ HTML في المستودع](./Study_Guide/Delegates_Part2_Lambda_Closures.html)**
- 🌐 الدليل التفاعلي (3/3): حل الأسئلة والمراجع الهندسية (HTML): **[🌐 معاينة حية في المتصفح (Live Preview)](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-02/blob/master/Study_Guide/Delegates_Part3_Quiz_Refs.html)** | **[📄 فتح ملف الـ HTML في المستودع](./Study_Guide/Delegates_Part3_Quiz_Refs.html)**
- 📂 **[فتح مجلد المحاضرة المحلي الكامل في `nots` (للتصفح المحلي على الجهاز)](../../../../nots/03_Advanced-CSharp/Session_02_Delegates_&_Lambdas)**

---

### 🧠 الملاحظات الهندسية والمفاهيم المعمارية (Engineering Notes)
1. **تشريح كائن الـ `Delegate` في الـ Heap:**
   - الـ `delegate` في C# هو كلاس مرجعي يرث من `System.MulticastDelegate` ويحتوي داخلياً على ثلاثة حقول رئيسية:
     - `_target`: مرجع للكائن الذي تُستدعى عليه الدالة (أو `null` للدوال الـ `static`).
     - `_methodPtr`: مؤشر عنوان الدالة في الذاكرة (`Function Pointer`).
     - `_invocationList`: مصفوفة من المفوضات عند دمج عدة دوال عبر `+=` (Multicast).
2. **الثلاثي القياسي المدمج (`Func`, `Action`, `Predicate`) في مشروع `ShopMaster`:**
   - بدلاً من كتابة كود بحث أو طباعة أو تحويل مكرر لكل حالة (مخالفة لمبدأ `DRY` و `OCP`)، تم حقن السلوك كمعاملات دالية (`Behavior Parameterization`):
     - **`Predicate<Product>` / `Func<Product, bool>`:** لتصفية وبحث المنتجات بأي شرط ديناميكي.
     - **`Action<Product>`:** لتوليد تقارير الطباعة بأشكال متعددة (`Short Report`, `Detailed Report`).
     - **`Func<Product, TResult>`:** لتحويل عناصر `Product` إلى ملخصات نصية أو أسعار بعد الخصم (`Projection / Transformation`).
3. **آلية عمل الـ `Closures` تحت السطح:**
   - عندما يلتقط تعبير `Lambda` متغيراً محلياً من الدالة المحيطة، يقوم المترجم بإنشاء كلاس خفي (`<>c__DisplayClass`) في الـ `Heap` لنقل ذلك المتغير إليه حتى يظل حياً طوال عمر الـ `Delegate`.

---

## 🗂️ هيكلة الكود والتمارين التطبيقية المحلولة

| الملف المصدري | الدور المعماري في نظام `ShopMaster` |
| :--- | :--- |
| [`Product.cs`](./Advanced-CSharp-02/Product.cs) & [`ProductCatalog.cs`](./Advanced-CSharp-02/ProductCatalog.cs) | نموذج المنتج وقاعدة بيانات المنتجات الأولية لمتجر `ShopMaster`. |
| [`ProductSearcher.cs`](./Advanced-CSharp-02/ProductSearcher.cs) | **Task 01:** محرك بحث ذكي يقبل أي شرط بحث ديناميكي عبر Delegate / `Func<Product, bool>`. |
| [`ReportEngine.cs`](./Advanced-CSharp-02/ReportEngine.cs) | **Task 03.1:** محرك تقارير يعتمد على `Action<Product>` لطباعة المنتجات بأي تنسيق مطلوب. |
| [`ProductTransformer.cs`](./Advanced-CSharp-02/ProductTransformer.cs) | **Task 03.2:** محول بيانات يعتمد على `Func<Product, TResult>` لعمل Projection للمنتجات. |
| [`ProductFilter.cs`](./Advanced-CSharp-02/ProductFilter.cs) | **Task 03.3:** مرشح منتجات يعتمد على `Predicate<Product>` لفصل شروط الفلترة عن منطق التكرار. |
| [`Program.cs`](./Advanced-CSharp-02/Program.cs) | تشغيل جميع السيناريوهات باستخدام `Lambda Expressions` ودمج الشروط. |

---

## 🧭 خريطة مسار هندسة `.NET` الكامل على GitHub

| # | المرحلة (Module) | المستودع (Repository) | الموضوع الرئيسي | الدليل التفاعلي (Live HTML) |
| :---: | :--- | :--- | :--- | :---: |
| **01** | `01_CSharp_Basics` | **[`CSharp-Basics02-Assigment`](https://github.com/mohamedadel452/CSharp-Basics02-Assigment)** | أنواع البيانات، نموذج الكائنات (System.Object)، والتحويلات | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics02-Assigment/blob/master/Study_Guide/CSharp_Basics_Session02_Guide.html) |
| **02** | `01_CSharp_Basics` | **[`CSharp-Basics03-Assigment`](https://github.com/mohamedadel452/CSharp-Basics03-Assigment)** | معمارية النصوص (Strings & StringBuilder)، جمل التحكم، والحلقات | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics03-Assigment/blob/master/Study_Guide/CSharp_Basics_Session03_Guide.html) |
| **03** | `01_CSharp_Basics` | **[`CSharp-Basics04-Assigment`](https://github.com/mohamedadel452/CSharp-Basics04-Assigment)** | المصفوفات (1D & 2D Arrays) وتمرير المعاملات للدوال (Value / ref / out / params) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics04-Assigment/blob/master/Study_Guide/CSharp_Basics_Session04_Guide.html) |
| **04** | `01_CSharp_Basics` | **[`CSharp-Basics05-Assigment`](https://github.com/mohamedadel452/CSharp-Basics05-Assigment)** | محددات الوصول (Access Modifiers)، التغليف، والـ Enums | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/CSharp-Basics05-Assigment/blob/master/Study_Guide/CSharp_Basics_Session05_Guide.html) |
| **05** | `02_OOP` | **[`OOP-Session-01-Assigment`](https://github.com/mohamedadel452/OOP-Session-01-Assigment)** | الـ Struct، التغليف، الخصائص، والـ Indexers (نظام Smart Delivery) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-01-Assigment/blob/master/Study_Guide/OOP_Session01_Deep_Dive.html) |
| **06** | `02_OOP` | **[`OOP-Session-02-Assigment`](https://github.com/mohamedadel452/OOP-Session-02-Assigment)** | الفئات (Classes)، الوراثة، وتسلسل الـ Constructors (Smart Delivery Part 1) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-02-Assigment/blob/master/Study_Guide/OOP_Session02_Deep_Dive.html) |
| **07** | `02_OOP` | **[`OOP-Session-03-Assigment`](https://github.com/mohamedadel452/OOP-Session-03-Assigment)** | تعدد الأشكال (Polymorphism)، الربط الديناميكي، والكلاسات المختومة (Sealed) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-03-Assigment/blob/master/Study_Guide/OOP_Session03_04_Dispatch_&_SOLID_Deep_Dive.html) |
| **08** | `02_OOP` | **[`OOP-Session-04-Assigment`](https://github.com/mohamedadel452/OOP-Session-04-Assigment)** | التجريد (Abstraction)، الفئات المجردة، والواجهات (Smart Delivery Part 3) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-04-Assigment/blob/master/Study_Guide/OOP_Session04_Deep_Dive.html) |
| **09** | `02_OOP` | **[`OOP-Session-05-Assigment`](https://github.com/mohamedadel452/OOP-Session-05-Assigment)** | نسخ الكائنات، Static، دوال التوسيع، والـ Partial Classes (Smart Delivery Final) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/OOP-Session-05-Assigment/blob/master/Study_Guide/OOP_Session05_Deep_Dive.html) |
| **10** | `03_Advanced_CSharp` | **[`Advanced-CSharp-01`](https://github.com/mohamedadel452/Advanced-CSharp-01)** | الأنواع المعممة (Generics)، القيود (Constraints)، والـ Variance | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-01/blob/master/Study_Guide/Generics_Deep_Part1_Core.html) |
| **11** | `03_Advanced_CSharp` | **[`Advanced-CSharp-02`](https://github.com/mohamedadel452/Advanced-CSharp-02)** | المفوضات (Delegates)، تعبيرات Lambda، ونظام ShopMaster | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-02/blob/master/Study_Guide/Delegates_Part1_Core.html) |
| **12** | `03_Advanced_CSharp` | **[`Advanced-CSharp-03`](https://github.com/mohamedadel452/Advanced-CSharp-03)** | معمارية هياكل البيانات والـ Collections (6 أنظمة تطبيقية) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Advanced-CSharp-03/blob/master/Study_Guide/session03-part1-collections-list.html) |
| **13** | `04_Database` | **[`Database-Session-01-Assigment`](https://github.com/mohamedadel452/Database-Session-01-Assigment)** | تصميم قواعد البيانات، مخططات الـ ERD، والتحويل العلائقي (Relational Mapping) | [🌐 فتح الشرح التفاعلي](https://htmlpreview.github.io/?https://github.com/mohamedadel452/Database-Session-01-Assigment/blob/master/Study_Guide/ERD_Part1_Design_Intro.html) |

---

## 🚀 طريقة التشغيل المحلي (How to Run)

```bash
git clone https://github.com/mohamedadel452/Advanced-CSharp-02.git
cd Advanced-CSharp-02
dotnet run --project "Advanced-CSharp-02/Advanced-CSharp-02.csproj"
```

**إعداد وتطوير:** [محمد عادل محمد بيومي (mohamedadel452)](https://github.com/mohamedadel452) — كلية الحاسبات والمعلومات، جامعة عين شمس.

</div>
