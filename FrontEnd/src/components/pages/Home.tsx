import React, { useEffect, useState } from "react";
import usePosts from "../../hooks/usePosts";
import PostCard from "../posts/PostCard";

const Home: React.FC = () => {
  const { posts, fetchPosts } = usePosts();
  const [postDeleted, setPostDeleted] = useState(false);

  useEffect(() => {
    fetchPosts();
  }, [postDeleted]);

  return (
    <div className="bg-white py-12 sm:py-16">
      <div className="mx-auto max-w-7xl px-6 lg:px-8">
        <div className="mx-auto max-w-2xl lg:mx-0">
          <h2 className="text-3xl font-bold tracking-tight text-gray-900 sm:text-4xl">
            Mi blog personal
          </h2>
          <p className="mt-2 text-lg leading-8 text-gray-600">Blog personal para post privados</p>
        </div>
        <div className="mx-auto mt-10 grid max-w-2xl grid-cols-1 gap-x-8 gap-y-16 border-t border-gray-200 pt-10 sm:mt-16 sm:pt-16 lg:mx-0 lg:max-w-none lg:grid-cols-1">
          {posts.map((post) => (
            <PostCard key={post.id} post={post} onDelete={() => setPostDeleted(!postDeleted)}/>
          ))}
        </div>
      </div>
    </div>
  );
};

export default Home;
