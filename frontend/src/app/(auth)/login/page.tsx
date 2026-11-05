import { X } from "lucide-react";
import Link from "next/link";

export default function LoginPage() {
  return (
    <div>
      <div className="relative max-w-md mx-auto mt-10 p-6 bg-white rounded-lg ">
        <div className="absolute top-0 right-0 p-4">
          <Link
            href="/"
            title="Ana Sayfaya Dön"
            className="cursor-pointer text-slate-600 hover:text-slate-900 transition rounded-full flex justify-center items-center p-2 hover:bg-slate-100 active:bg-slate-200"
          >
            <X className="inline-block" />
          </Link>
        </div>

        <div className="mb-6 flex flex-col gap-2 justify-cenetr items-center">
          <h1 className="font-bold text-2xl">Tekrar hoş geldiniz!</h1>
          <p className="text-slate-600 font-light">
            Hesabınıza giriş yapmak için lütfen bilgilerinizi girin.
          </p>
        </div>
        <form>
          <div className="mb-4 flex flex-col">
            <label
              className="block text-slate-700 font-medium mb-2"
              htmlFor="email"
            >
              E-posta
            </label>
            <input
              className="border border-slate-300 rounded-md py-2 px-4 focus:outline-none focus:ring-2 focus:ring-blue-500 bg-slate-100/30"
              type="email"
              id="email"
              name="email"
              placeholder="ornek@email.com"
              required
            />
          </div>
          <div className="mb-4 flex flex-col">
            <label
              className="block text-slate-700 font-medium mb-2"
              htmlFor="password"
            >
              Şifre
            </label>
            <input
              className="border border-slate-300 rounded-md py-2 px-4 focus:outline-none focus:ring-2 focus:ring-blue-500 bg-slate-100/30"
              type="password"
              id="password"
              name="password"
              placeholder="Şifrenizi girin"
              required
            />
          </div>
          <button className="mt-4 bg-slate-800 text-white py-2 px-4 rounded-lg hover:bg-slate-700 active:bg-slate-600 transition cursor-pointer w-full">
            Giriş Yap
          </button>
        </form>

        <div className="mt-4 text-center">
          <p className="text-slate-600">
            Hesabınız yok mu?{" "}
            <a
              href="/register"
              className="text-blue-500 hover:underline cursor-pointer"
            >
              Hemen Kayıt Olun
            </a>
          </p>
        </div>
      </div>
    </div>
  );
}
