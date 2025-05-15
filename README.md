# 🧪 HRM Automation Testing with Selenium + C# + NUnit

Bu proje, bir **HRM (Human Resource Management)** web uygulamasının **Employee Center ve HR Center** modülünde yapılan test otomasyon sürecini temsil eder.  
Amaç; gerçek bir web uygulamasında, Selenium WebDriver kullanarak belirli form işlemlerini otomatikleştirmek ve token tabanlı authentication senaryolarını yönetmektir.

## 📌 Neler Yapıldı?

- ✅ **Login işlemi sonrası token'ın Local Storage'dan alınması**  
- 🔐 **Token yönetimi için Singleton yapıda `TokenManager` servisi oluşturulması**  
- 🧠 **Token’ın farklı test senaryolarında yeniden kullanılması**  
- 📄 **İzin formu sayfasına yönlenip form inputlarının dinamik olarak doldurulması**  
- 📆 **Tarih alanlarında bugünün sonrasına denk gelen rastgele tarih üretimi**  
- 🔄 **Modal, drawer ve dropdown gibi UI bileşenleriyle çalışma**  
- ✔️ **NUnit ile assertion’lar ve senaryo doğrulamaları**

## 🛠️ Kullanılan Teknolojiler

- Selenium WebDriver  
- C#  
- NUnit  
- JavaScript Executor (token okuma/yazma için)  
- Fluent Wait ve Explicit Wait örnekleri

## ⚠️ Gizlilik Notu

Bu proje, **çalıştığım şirkete ait gerçek bir HRM uygulaması üzerinde yapılan test senaryolarını** içermektedir.  
Ancak, **gizlilik sözleşmesi kapsamında uygulamaya veya firma detaylarına ait herhangi bir bilgi paylaşılmamıştır.**  
Repository yalnızca **otomasyon testi yaklaşımımın ve kod kalitemin incelenmesi amacıyla** oluşturulmuştur.

## 📂 Klasör Yapısı

```bash
HRM_Tests/
├── EC/
│   ├── TokenManagement/
│   │   └── ECTokenManager.cs
│   └── Leaves/
│       └── Leaves.cs
├── Tests/
│   └── LeavesTests.cs
└── README.md
```

## 🤝 Katkıda Bulunmak
Kod yapısı veya test stratejisiyle ilgili fikirleriniz varsa PR veya issue oluşturmaktan çekinmeyin!

📬 Her türlü geri bildirime açığım:
💼 https://www.linkedin.com/in/mehmet-albayrak-15406b174/ 
