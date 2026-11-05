import Link from "next/link";

export function Navbar() {
  return (
    <header className=" border-b-2 backdrop-blur-3xl bg-slate-100/30 border-slate-50/20 sticky top-0 z-50 shadow-sm">
      <div className="max-w-7xl mx-auto px-4 h-16 flex items-center justify-between">
        <Link
          href="/"
          className="flex items-center gap-2 font-bold text-xl text-black"
        >
          <span>Travel.io</span>
        </Link>

        <nav className="flex items-center gap-6 text-sm font-medium text-slate-600">
          <Link href="/" className="hover:text-slate-900 transition">
            Tüm Konaklamalar
          </Link>

          <Link 
            href="/"
            className=" font-bold border-2 border-slate-800 text-black px-4 py-2 rounded-lg hover:bg-slate-800 hover:text-white transition"
          >
            Giriş Yap
          </Link>
        </nav>
      </div>
    </header>
  );
}
