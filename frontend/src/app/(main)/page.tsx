import { Search } from "lucide-react";

export default function Home() {
  const HERO_IMAGE_URL =
    "https://images.unsplash.com/photo-1507525428034-b723cf961d3e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1470&q=80";

  return (
    <div className="space-y-8 pb-16">
      {/* Hero Bölümü */}
      <section className="relative flex flex-col items-center justify-center gap-4 bg-amber-900 h-96">
        <div
          style={{ backgroundImage: `url(${HERO_IMAGE_URL})` }}
          className="w-full h-96 bg-cover bg-center absolute inset-0"
        />

        <div className="relative z-10 text-center px-4 space-y-24">
          <h1 className="text-4xl font-bold text-black dark:text-white">
            Hayalindeki tatil yerini şimdi bul
          </h1>

          <div className="mt-4 bg-slate-50 border-2 border-slate-200 rounded-lg p-2 flex flex-col sm:flex-row gap-4 items-center">
            <div className="bg-slate-100 border-gray-300 rounded-md">
              <label
                htmlFor="search"
                className="text-sm pl-3 font-medium text-gray-700 flex items-start"
              >
                Konum
              </label>

              <input
                type="text"
                name="search"
                id="search"
                className=" block w-64  py-2 pl-3 pr-4 sm:text-sm  "
                placeholder="Konaklayacağınız yeri girin..."
              />
            </div>

            <div className="*:cursor-pointer hover:bg-slate-200 text-slate-700 font-bold py-2 px-4 rounded-md">
              <label
                htmlFor="checkin"
                className="text-sm pl-3 font-medium text-gray-700 flex items-start"
              >
                Check-in tarihi
              </label>

              <input
                type="date"
                name="checkin"
                id="checkin"
                className="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-3 sm:text-sm border-gray-300 rounded-md"
              />
            </div>

            <div className="*:cursor-pointer hover:bg-slate-200 text-slate-700 font-bold py-2 px-4 rounded-md">
              <label
                htmlFor="checkout"
                className="text-sm pl-3 font-medium text-gray-700 flex items-start"
              >
                Check-out tarihi
              </label>

              <input
                type="date"
                name="checkout"
                id="checkout"
                className="focus:ring-indigo-500 focus:border-indigo-500 block w-full pl-3 sm:text-sm border-gray-300 rounded-md"
              />
            </div>

            <div className="">
              <label
                htmlFor="guests"
                className="text-sm pl-3 font-medium text-gray-700 flex items-start"
              >
                Konuk ve oda sayısı
              </label>

              <button name="guests" className="hover:bg-slate-200 text-slate-700 font-bold py-2 px-4 cursor-pointer rounded-md">
                2 yetişkin, 1 çocuk, 1 oda
              </button>
            </div>

            <div >
              <button className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 cursor-pointer rounded-md flex items-center">
                <Search className="w-4 h-4 mr-2 inline-block" />
                Ara
              </button>
            </div>
          </div>
        </div>
      </section>

      {/* Popüler Konaklamalar */}
      <section className="relative max-w-7xl mx-auto px-8  rounded-lg flex flex-col gap-8 py-8">
        <h2 className="text-2xl font-bold text-black dark:text-white">
          Popüler konaklamalar
        </h2>

        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
          <div className="bg-white border shadow-lg border-slate-300 rounded-lg flex flex-col cursor-pointer hover:bg-slate-100 transition-transform">
            <div className="h-44 w-full bg-gray-200 rounded-t-lg"></div>

            <div className="flex flex-col gap-10 px-3 py-2">
              <div>
                <h3 className="text-lg font-semibold text-black dark:text-white">
                  Konaklama Adı
                </h3>
                <p className="text-gray-600 dark:text-gray-300">
                  Konaklama Konumu
                </p>
              </div>

              <div className="mt-2 flex items-center justify-between">
                <p className="text-sm">Değerlendirme: 4.5/5</p>
                <p className="text-sm">Fiyat: 500 TL</p>
              </div>
            </div>
          </div>

          <div className="bg-white border-2 border-slate-200 rounded-lg p-4">
            Kart 2
          </div>
        </div>
      </section>
    </div>
  );
}
