import AccomodationCard from "@/components/AccomodationCard";
import { SearchBar } from "@/components/SearchBar";

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

          <SearchBar />
        </div>
      </section>

      {/* Popüler Konaklamalar */}
      <section className="relative max-w-7xl mx-auto px-8  rounded-lg flex flex-col gap-8 py-8">
        <h2 className="text-2xl font-bold text-black dark:text-white">
          Popüler konaklamalar
        </h2>

        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
          <AccomodationCard />

          <AccomodationCard />

          <AccomodationCard />

          <AccomodationCard />
        </div>
      </section>
    </div>
  );
}
