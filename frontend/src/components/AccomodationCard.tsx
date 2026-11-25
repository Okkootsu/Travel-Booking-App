{
  /* ****************** YATAY VERSİYON ******************* */
  /* <div className="bg-white border shadow-lg border-slate-300 rounded-lg flex cursor-pointer hover:bg-slate-100 transition-transform w-180 h-55">
            <div className="h-size w-45 bg-gray-200 rounded-l-lg"></div>

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
          </div> */
}

export default function AccomodationCard() {
  return (
    <div className="bg-white border shadow-lg border-slate-300 rounded-lg flex flex-col cursor-pointer hover:bg-slate-100 transition-transform ">
      <div className="h-44 w-full bg-gray-200 rounded-t-lg"></div>

      <div className="flex flex-col gap-10 px-3 py-2">
        <div>
          <h3 className="text-lg font-semibold text-black dark:text-white">
            Konaklama Adı
          </h3>
          <p className="text-gray-600 dark:text-gray-300">Konaklama Konumu</p>
        </div>

        <div className="mt-2 flex items-center justify-between">
          <p className="text-sm">Değerlendirme: 4.5/5</p>
          <p className="text-sm">Fiyat: 500 TL</p>
        </div>
      </div>
    </div>
  );
}
