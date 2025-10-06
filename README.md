# Eğitim Amaçlı Keylogger (Kişisel Rıza ile)

## Proje Hakkında

Bu depo, ders kapsamında hazırlanmış **eğitim amaçlı** bir keylogger uygulamasına ait açıklama ve belgeleri içerir. Projenin amacı güvenlik konseptlerini öğrenmek, saldırı yüzeylerini anlamak ve savunma/test yaklaşımlarını değerlendirebilmektir. Bu repo **gerçek tuş kaydetme teknikleri veya kötüye kullanım talimatları içermez** — sadece proje bağlamı, etik çerçeve, test planı ve izin/sözleşme şablonları sunar.

---

## Hedefler

* Bilgi güvenliği dersleri kapsamında saldırı/defans senaryolarını kavramak.
* Güvenlik testleri sırasında etik sınırların ve yasal yükümlülüklerin önemini öğrenmek.
* İzole test ortamı (VM/lab) kurma ve veri sınırlama/prensiplerini uygulamalı olarak görmek.
* Kayıt edilen hassas verilerin korunması ve güvenli şekilde yok edilmesi süreçlerini anlamak.

---

## Kapsam ve Sınırlamalar

* **Kapsam:** Proje, eğitim amaçlı senaryolar, etik tartışmalar, test planları ve onay formu şablonları içerir.
* **Sınırlama:** Depoda veya dökümantasyonda gerçek sistemlere zarar verebilecek teknik uygulama talimatları, "ready-to-run" kötü amaçlı kod veya kötüye kullanım kılavuzları bulunmaz.

---

## Etik ve Yasal Uyarı

* Bu tür bir yazılımın geliştirilmesi ve çalıştırılması ciddi etik ve yasal sorumluluklar getirir.
* Herhangi bir kişiye ait cihazda veri toplayabilmek için **açık, yazılı ve geri çekilebilir rıza** almak zorunludur.
* Rıza olmadan yapılacak tüm işlemler suç teşkil edebilir; proje sahibinin ve çalıştıranın yasal sorumlulukları vardır.

---

## Güvenli Test Ortamı (Öneriler)

* Testleri **fiziksel olarak izole edilmiş bir laboratuvar ortamı** veya sanal makinede (VM) gerçekleştir.
* İnternete bağlı canlı kullanıcı cihazlarında kesinlikle test yapma.
* Test verilerini yalnızca eğitim amacıyla, sınırlı süreyle sakla; iş bitiminde **kalıcı olarak sil**.
* Kullanılan VM veya test ortamında anlık görüntü (snapshot) al; gerektiğinde geri dön.

---

## Test Planı (Basit Akış)

1. Test ortamı hazırlanır (ayrı VM, izole ağ).
2. Katılımcılardan yazılı rıza alınır.
3. Deney başlatılır; hangi verilerin toplanacağı ve amaç tekrar hatırlatılır.
4. Deney sonrası veriler güvenli biçimde toplanır, analiz edilir ve sonuçlar raporlanır.
5. Tüm ham veriler projenin kapatılmasından sonra güvenli şekilde silinir.

---

## Veri Gizliliği ve Saklama

* Toplanan veriler en az tutulmalı; analiz tamamlandığında **güvenli** biçimde yok edilmelidir.
* Verilere erişim sadece proje ekibiyle sını
