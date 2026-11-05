import { X } from "lucide-react";
import Link from "next/link";

export default function RegisterPage() {
  return (
    <div>
      <div className="relative max-w-md mx-auto mt-10 p-6 bg-white rounded-lg flex flex-col gap-6">
        <div className="absolute top-0 right-0 p-4">
          <Link
            href="/"
            title="Ana Sayfaya Dön"
            className="cursor-pointer text-slate-600 hover:text-slate-900 transition rounded-full flex justify-center items-center p-2 hover:bg-slate-100 active:bg-slate-200"
          >
            <X className="inline-block" />
          </Link>
        </div>

        <div className="flex flex-col gap-2 justify-cenetr items-center">
          <h1 className="font-bold text-2xl">Hesap Oluştur</h1>
          <p className="text-slate-600 font-light">
            Yeni bir hesap oluşturmak için lütfen bilgilerinizi girin.
          </p>
        </div>

        <form className="flex flex-col gap-3">
          <div className=" flex flex-col">
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
          <div className=" flex flex-col">
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

          <div className=" flex flex-col">
            <label
              className="block text-slate-700 font-medium mb-2"
              htmlFor="password"
            >
              Şifre (Tekrar)
            </label>
            <input
              className="border border-slate-300 rounded-md py-2 px-4 focus:outline-none focus:ring-2 focus:ring-blue-500 bg-slate-100/30"
              type="password"
              id="password-confirm"
              name="password-confirm"
              placeholder="Şifrenizi tekrar girin"
              required
            />
          </div>

          <button className="mt-6 bg-slate-800 text-white py-2 px-4 rounded-lg hover:bg-slate-700 active:bg-slate-600 transition cursor-pointer w-full">
            Kayıt Ol
          </button>
        </form>

        <div className=" text-center">
          <p className="text-slate-600">
            Zaten bir hesabınız var mı?{" "}
            <a
              href="/login"
              className="text-blue-500 hover:underline cursor-pointer"
            >
              Hemen Giriş Yapın
            </a>
          </p>
        </div>
      </div>
    </div>
  );
}
