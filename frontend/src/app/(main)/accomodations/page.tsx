import AccomodationCard from "@/components/AccomodationCard";
import { SearchBar } from "@/components/SearchBar";

export default function Accomodations() {
  return (
    <div className="flex-1 flex flex-col ">
      <div className="max-w-[%80] flex justify-center items-center">
        <SearchBar />
      </div>

      <div className="flex gap-8 py-8 px-36">
        <div className="rounded border-2 w-75 min-h-75 flex justify-center items-center">
          Diğer Filtreler
        </div>

        <div className="flex-1 grid grid-cols-3 sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6 ">
          <AccomodationCard />

          <AccomodationCard />

          <AccomodationCard />

          <AccomodationCard />

          <AccomodationCard />
        </div>
      </div>
    </div>
  );
}
