require "rake"
require "bundler/gem_tasks"

task :default => :build

task :build do
  sh "gem build bancos_brasileiros.gemspec"
end
task :release => [:build] do
  sh "gem push $(ls *.gem)"
end
