import React from "react";
import { Routes, Route } from "react-router-dom";
import Home from "./components/pages/Home";
import Login from "./components/auth/Login";
import PostCreateForm from "./components/posts/PostCreateForm";
import PostEditForm from "./components/posts/PostEditForm";
import ProtectedRoute from "./components/ProtectedRoute";
import Layout from "./components/layout/Layout";

const Main = () => {
  return (
    <div>
      <Routes>
        <Route
          path="/"
          element={<Layout />}
          children={
            <>
              <Route path="/login" element={<Login />} />
              <Route
                path="/"
                element={
                  <ProtectedRoute>
                    <Home />
                  </ProtectedRoute>
                }
              />
              <Route
                path="/posts/create"
                element={
                  <ProtectedRoute>
                    <PostCreateForm />
                  </ProtectedRoute>
                }
              />
              <Route
                path="/posts/edit/:postId"
                element={
                  <ProtectedRoute>
                    <PostEditForm />
                  </ProtectedRoute>
                }
              />
            </>
          }
        />
      </Routes>
    </div>
  );
};

export default Main;
