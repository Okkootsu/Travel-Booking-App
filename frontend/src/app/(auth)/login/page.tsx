"use client";

import { useAuth } from "@/features/auth/AuthContext";
import { ApiError } from "@/lib/api-client";
import { Loader2, X } from "lucide-react";
import Link from "next/link";
import { useRouter, useSearchParams } from "next/navigation";
import { Suspense, useState } from "react";
import toast from "react-hot-toast";

function LoginForm() {
  const router = useRouter();
  const searchParams = useSearchParams();
  const redirect = searchParams.get("redirect") || "/dashboard";

  const { login } = useAuth();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [isLoading, setIsLoading] = useState(false);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsLoading(true);
    setErrorMessage(null);

    try {
      await login({ email, password });

      toast.success("Giriş başarılı! Yönlendiriliyorsunuz...");
      router.push(redirect);
      router.refresh();
    } catch (err) {
      let msg = "Giriş yapılırken bir hata oluştu. Lütfen tekrar deneyin.";

      if (err instanceof ApiError) {
        if (err.errors) {
          const firstKey = Object.keys(err.errors)[0];
          msg = err.errors[firstKey][0];
        } else {
          msg = err.message;
        }
      }

      setErrorMessage(msg);
      toast.error(msg);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <>
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

      <form onSubmit={handleSubmit}>
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
            value={email}
            onChange={(e) => setEmail(e.target.value)}
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
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Şifrenizi girin"
            required
          />
        </div>

        <button
          disabled={isLoading}
          type="submit"
          className="mt-4 bg-slate-800 text-white py-2 px-4 rounded-lg hover:bg-slate-700 active:bg-slate-600 transition cursor-pointer w-full"
        >
          {isLoading ? (
            <div className="flex justify-center items-center gap-2">
              <Loader2 className="w-4 h-4 animate-spin" />
              <span>Giriş Yapılıyor...</span>
            </div>
          ) : (
            <>
              <span>Giriş Yap</span>
            </>
          )}
        </button>
      </form>

      <div className="mt-4 text-center">
        <div className="text-slate-600">
          Hesabınız yok mu?{" "}
          <Link
            href={`/register${redirect !== "/dashboard" ? `?redirect=${encodeURIComponent(redirect)}` : ""}`}
            className="text-blue-500 hover:underline cursor-pointer"
          >
            Hemen Kayıt Olun
          </Link>
        </div>
      </div>
    </>
  );
}

export default function LoginPage() {
  return (
    <div>
      <div className="relative max-w-md mx-auto mt-10 p-6 bg-white rounded-lg ">
        <Suspense
          fallback={
            <div className="text-center text-sm text-slate-400">
              Yükleniyor...
            </div>
          }
        >
          <LoginForm />
        </Suspense>
      </div>
    </div>
  );
}
