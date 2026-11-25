import { Search } from "lucide-react";

export function SearchBar() {
  return (
    <div className="mt-4 bg-slate-50 border-2 border-slate-200 rounded-lg p-2 flex flex-col sm:flex-row gap-4 items-center w-max">
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

        <button
          name="guests"
          className="hover:bg-slate-200 text-slate-700 font-bold py-2 px-4 cursor-pointer rounded-md"
        >
          2 yetişkin, 1 çocuk, 1 oda
        </button>
      </div>

      <div>
        <button className="bg-blue-500 hover:bg-blue-600 text-white font-bold py-2 px-4 cursor-pointer rounded-md flex items-center">
          <Search className="w-4 h-4 mr-2 inline-block" />
          Ara
        </button>
      </div>
    </div>
  );
}
