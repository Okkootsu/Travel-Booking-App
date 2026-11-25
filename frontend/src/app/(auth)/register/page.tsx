"use client";

import { useAuth } from "@/features/auth/AuthContext";
import { ApiError } from "@/lib/api-client";
import { Loader2, X } from "lucide-react";
import Link from "next/link";
import { useRouter, useSearchParams } from "next/navigation";
import { Suspense, useState } from "react";
import toast from "react-hot-toast";

function RegisterForm() {
  const router = useRouter();
  const searchParams = useSearchParams();
  const redirect = searchParams.get("redirect") || "/dashboard";

  const { register } = useAuth();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");

  const [isLoading, setIsLoading] = useState(false);
  const [generalError, setGeneralError] = useState<string | null>(null);
  const [fieldErrors, setFieldErrors] = useState<Record<string, string[]>>({});

  // loading testi için
  const sleep = (ms: number) =>
    new Promise((resolve) => setTimeout(resolve, ms));

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setIsLoading(true);
    setGeneralError(null);
    setFieldErrors({});

    try {
      if (password !== confirmPassword) {
        const msg = "Lütfen şifrelerin uyuştuğundan emin olun.";
        setGeneralError(msg);
        toast.error(msg);
        return;
      }

      await register({ email, password });

      toast.success("Hesabınız başarıyla oluşturuldu! Yönlendiriliyorsunuz...");
      router.push(redirect);
      router.refresh();
    } catch (err) {
      if (err instanceof ApiError) {
        if (err.errors) {
          setFieldErrors(err.errors);
          const firstKey = Object.keys(err.errors)[0];
          toast.error(err.errors[firstKey][0]);
        } else {
          setGeneralError(err.message);
          toast.error(err.message);
        }
      } else {
        const msg = "Kayıt işlemi sırasında beklenmeyen bir hata oluştu.";
        setGeneralError(msg);
        toast.error(msg);
      }
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

      <div className="flex flex-col gap-2 justify-cenetr items-center">
        <h1 className="font-bold text-2xl">Hesap Oluştur</h1>
        <p className="text-slate-600 font-light">
          Yeni bir hesap oluşturmak için lütfen bilgilerinizi girin.
        </p>
      </div>

      <form className="flex flex-col gap-3" onSubmit={handleSubmit}>
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
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="ornek@email.com"
            required
          />
          {fieldErrors.Email && (
            <p className="text-xs text-red-600 mt-1 font-medium">
              {fieldErrors.Email[0]}
            </p>
          )}
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
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Şifrenizi girin"
            required
          />
          {fieldErrors.Password && (
            <p className="text-xs text-red-600 mt-1 font-medium">
              {fieldErrors.Password[0]}
            </p>
          )}
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
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            placeholder="Şifrenizi tekrar girin"
            required
          />
        </div>

        <button
          type="submit"
          disabled={isLoading}
          className="mt-6 bg-slate-800 text-white py-2 px-4 rounded-lg hover:bg-slate-700 active:bg-slate-600 transition cursor-pointer w-full"
        >
          {isLoading ? (
            <div className="flex justify-center items-center gap-2">
              <Loader2 className="w-4 h-4 animate-spin" />
              <span>Hesap Oluşturuluyor...</span>
            </div>
          ) : (
            <>
              <span>Kayıt Ol</span>
            </>
          )}
        </button>
      </form>

      <div className=" text-center">
        <div className="text-slate-600">
          Zaten bir hesabınız var mı?{" "}
          <Link
            href={`/login${redirect !== "/dashboard" ? `?redirect=${encodeURIComponent(redirect)}` : ""}`}
            className="text-blue-500 hover:underline cursor-pointer"
          >
            Hemen Giriş Yapın
          </Link>
        </div>
      </div>
    </>
  );
}

export default function RegisterPage() {
  return (
    <div>
      <div className="relative max-w-md mx-auto mt-10 p-6 bg-white rounded-lg flex flex-col gap-6">
        <Suspense
          fallback={
            <div className="text-center text-sm text-slate-400">
              Yükleniyor...
            </div>
          }
        >
          <RegisterForm />
        </Suspense>
      </div>
    </div>
  );
}
